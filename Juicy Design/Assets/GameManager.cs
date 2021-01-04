using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public float score;
    public Text scoreText;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void UpdateScore()
    {
        score += 10;
    }
}
