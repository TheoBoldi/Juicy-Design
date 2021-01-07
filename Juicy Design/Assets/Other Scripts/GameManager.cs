using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject endCanvas;
    private GameObject player;

    [Header("Score")]
    [HideInInspector] public float score;
    public Text scoreText;
    public int triggerInsects;

    [Header("Life")]
    public int maxLife;
    private int actualLife;
    public Text lifeText;

    private float randomBurp;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        score = 0;
        actualLife = maxLife;
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        randomBurp = Random.Range(10, 20);
    }

    private void Update()
    {
        scoreText.text = "Score : " + score.ToString();
        lifeText.text = "Life : " + actualLife.ToString();

        randomBurp -= Time.deltaTime;

        if(randomBurp <= 0)
        {
            randomBurp = Random.Range(10, 20);
            SoundManager.instance.Play("Burp");
        }
    }

    public void UpdateScore()
    {
        score += 10;

        if(score == triggerInsects)
        {
            SoundManager.instance.Play("Insects");
        }
    }

    public void DecreaseLife()
    {
        actualLife--;

        if(actualLife <= 0)
        {
            SoundManager.instance.Play("PlayerDeath");
            Destroy(player);
            Instantiate(endCanvas);
        }
        else
        {
            SoundManager.instance.Play("PlayerHit");
        }
    }
}
