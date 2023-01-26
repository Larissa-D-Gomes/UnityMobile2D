using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score, highScore;
    public float currentTime;
    public bool gameStarted; 

    [SerializeField] private float startTime;
    private UIController uiController;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        score = 0;
        currentTime = startTime;
        uiController = FindObjectOfType<UIController>();
        highScore = GetScore();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartGame()
    {
        gameStarted = true;
        InvokeCoundownTime();
    }

    public void ReturnToMainMenu()
    {
        score = 0;
        currentTime = 0;
        gameStarted = false;
        CancelInvoke("CountdownTime");
    }

    public void InvokeCoundownTime()
    {
        uiController.txtTime.text = currentTime.ToString();
        // Começa a chamar o método CountdownTime em 1 segundo e 
        // repete a camada a cada 1 segundo
        InvokeRepeating("CountdownTime", 1f, 1f);
    }

    public void CountdownTime()
    {
        uiController.txtTime.text = currentTime.ToString();
        if(currentTime > 0f && gameStarted)
        {
            currentTime -= 1f;
        } 
        else
        {
            uiController.panelGameOver.SetActive(true);
            uiController.panelGame.SetActive(true);
            gameStarted = false;
            currentTime = 0f;
            SaveScore();
            CancelInvoke("CountdownTime");
            return;
        }
    }

    public void SaveScore()
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }

    public int GetScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }
}
