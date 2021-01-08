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
    public GameObject saussagesParent;
    public List<GameObject> saussages;
    private int actualSaussage;
    public Text lifeText;

    private float randomBurp;

    public JuicyLayersManager layerManager;
    private void Awake()
    {
        instance = this;
        layerManager = FindObjectOfType<JuicyLayersManager>();
    }

    private void Start()
    {
        score = 0;
        actualLife = maxLife;
        actualSaussage = 4;
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        randomBurp = Random.Range(10, 20);

        for(int i = 0; i < saussagesParent.transform.childCount; i++)
        {
            saussages.Add(saussagesParent.transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        scoreText.text = "Score : " + score.ToString();

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
        saussages[actualSaussage].GetComponent<Animator>().SetTrigger("Hit");
        actualSaussage--;
        lifeText.text = "Life : " + actualLife.ToString();
        if(actualLife <= 0)
        {
            SoundManager.instance.Play("PlayerDeath");
            Destroy(player);
            Instantiate(endCanvas);
        }
        else
        {
            SoundManager.instance.Play("PlayerHit");
            player.GetComponentInChildren<Animator>().SetTrigger("Hurt");
        }
    }
}
