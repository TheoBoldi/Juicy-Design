using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCanvas : MonoBehaviour
{
    private GameObject scoreCanvas;
    private GameManager gameManager;
    public Text scoreText;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        scoreText.text = "Your score : " + gameManager.score.ToString();

        Time.timeScale = 0;
    }
    
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
