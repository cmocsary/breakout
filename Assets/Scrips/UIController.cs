using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//clase para controlar comportamiento de toda la parte de UI del juego
public class UIController : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winnerPanel;
    [SerializeField] GameObject[] livesImg;
    [SerializeField] Text gameTimeText;
    [SerializeField] Text keyWordLevel;
    
    
    public void ActivateLosePanel()
    {
        losePanel.SetActive(true);
    }
    public void ActivateWinnerPanel(float gameTime, string keyword)
    {
        winnerPanel.SetActive(true);
        gameTimeText.text = "Game Time: " + Mathf.Floor(gameTime) + "s";
        keyWordLevel.text = keyword;
    }
    public void RestartCurrentScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void UpdateUILives(byte currentLives)
    {
        for(int i=0; i<livesImg.Length; i++)
        {
            if(i >= currentLives)
            {
                livesImg[i].SetActive(false);
            }
        }
    }
    public void NextScene()
    {
        string actualScene = SceneManager.GetActiveScene().name;
        Debug.Log(SceneManager.GetActiveScene().name);
        switch(actualScene)
        {
            case "Game":
                SceneManager.LoadScene("GameTwo");
                break;
            case "GameTwo":
                SceneManager.LoadScene("GameThree");
                break;
            case "GameThree":
                SceneManager.LoadScene("FinalGame");
                break;
            default:
                break;
        }
    }
}
