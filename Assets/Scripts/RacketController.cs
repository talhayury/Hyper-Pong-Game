using Unity.VisualScripting;
using UnityEngine;

public class RacketController : MonoBehaviour
{


    [SerializeField] private float speed;
    [SerializeField] private float limitHorizontal = 2.2f;

    [SerializeField] private bool _isPlayer;

    public bool isUp;
    
    
    private void Update() {

        Vector3 newPosition = transform.position;

        if(_isPlayer){
            var input = Input.GetAxis("Horizontal");
            newPosition = transform.position + (Vector3.right*(input*speed*Time.deltaTime));
        }else{
            var ai = BallController.Instance.transform.position.x;
            newPosition.x = ai;
        }
        newPosition.x = Mathf.Clamp(newPosition.x ,-limitHorizontal,+limitHorizontal);
        transform.position = newPosition;
        
    }
}
