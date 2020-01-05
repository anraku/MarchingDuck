using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public Text scoreText;
    int score;
    public int clearNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(score >= clearNumber)
        {
            // game clear
            SceneManager.LoadScene("ClearScene");
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "SCORE:" + score;
    }

    public void PushRetryButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void DisplayGameOverCanvas()
    {
        gameOverCanvas.SetActive(true);
    }
}
