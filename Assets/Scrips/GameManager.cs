
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //utilizamos propiedades para manejar el estado del juego
    public static GameManager Instance { get; private set; }
    private float gameTime;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }   
    [SerializeField] byte bricksOnLevel;
    public byte BricksOnLevel {
        get => bricksOnLevel;
        set
        {
            bricksOnLevel = value;
            if (bricksOnLevel == 0)
            {
                Debug.Log("Has ganado");
                Destroy(GameObject.Find("Ball"));
                //se calcula el tiempo de juego al destruir todos los bloques
                gameTime = Time.time * gameTime;
                //se obtiene palabra clave
                string keywordToUse = FindObjectOfType<TopicsDictionary>().GetRandomKeyword();
                //muestra pantalla de victoria
                FindObjectOfType<UIController>().ActivateWinnerPanel(gameTime, keywordToUse);
                gameTime = Time.time - gameTime;
            }
        }
    }
    [SerializeField] byte playerLives;
    public byte PlayerLives
    {
        get => playerLives;
        set
        {
            playerLives = value;
            if (playerLives == 0)
            {
                Debug.Log("Has Perdido");
                Destroy(GameObject.Find("Ball"));
                //se muestra pantalla de derrota
                FindObjectOfType<UIController>().ActivateLosePanel();
            }
            else
            {
                FindObjectOfType<Ball>().ResetBall();
            }
            FindObjectOfType<UIController>().UpdateUILives(playerLives);
        }
    }
    [SerializeField] bool gameStarted;
    public bool GameStarted
    {
        get => gameStarted;
        set
        {
            gameStarted = value;
            //guardamos el tiempo transcurrido desde el inicio del juego
            gameTime = Time.time;
        }
    }
    [SerializeField] bool ballOnPlay;
    public bool BallOnPlay
    {
        get => ballOnPlay;
        set
        {
            ballOnPlay = value;
            if (ballOnPlay == true)
            {
                Debug.Log("Lanzar bola");
                FindObjectOfType<Ball>().LaunchBall();
            }
        }
    }
    public string Topic {get;set;}
}
