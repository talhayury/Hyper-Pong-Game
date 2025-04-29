using UnityEngine;

public class BallController : MonoBehaviour
{

    public static BallController Instance{get ; private set;}
    [SerializeField] private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _speed;

    private void Awake() {
        Instance = this;
    }

    public void OnStart() {
        transform.position = Vector2.zero;
        _rigidbody2D.AddForce(Vector2.down*_speed);

    }
 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Racket")){
            var racket = other.transform.GetComponent<RacketController>();
            var directionVertical = racket.isUp ? -1 : 1;
            var directionHorizontal = (transform.position.x - racket.transform.position.x)/other.collider.bounds.extents.x;

            _rigidbody2D.AddForce(new Vector2(directionHorizontal,directionVertical).normalized*_speed);

            
        }

        if(other.transform.CompareTag("Racket1")){
            var racket = other.transform.GetComponent<RacketController>();
            var directionVertical = racket.isUp ? -1 : 1;
            var directionHorizontal = (transform.position.x - racket.transform.position.x)/other.collider.bounds.extents.x;

            _rigidbody2D.AddForce(new Vector2(directionHorizontal,directionVertical).normalized*_speed);

            
            GameManager.Instance.Skor++;
            GameManager.Instance.Score.text =  GameManager.Instance.Skor.ToString();
            
        }

        if(other.transform.CompareTag("Goal")){
            //score
        }

        if(other.transform.CompareTag("GoalGameOver")){
            //game over
            GameManager.Instance.OnGameOver();
            _rigidbody2D.linearVelocity = Vector2.zero;
            GameManager.Instance.Skor = 0;
            
        }
        
        
    }
}
