using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Canvas _scoreCanvas;

    public TMP_Text Score;

    public int Skor {get; set;}



    private void Awake() {
        Instance = this;
        
    }



    public void OnClick_StartButton(){
        _canvas.enabled=false;
        BallController.Instance.OnStart();
    }

    public void OnGameOver(){
        _canvas.enabled = true;
        
    }
}
