using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("General Sounds")]
    public AudioSource mainTheme;

    [Header("Player Sounds")]
    public AudioSource shoot;
    public AudioSource hit;
    public AudioSource death;
    public AudioSource miss;

    [Header("Enemies Sounds")]
    public AudioSource enemyDeath;

    [Header("Ambiance Sounds")]
    public AudioSource insects;
    public AudioSource burp;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        instance.MainTheme();
    }

    //General
    public void MainTheme()
    {
        mainTheme.Play();
    }

    //Player
    public void Shoot()
    {
        shoot.pitch = Random.Range(0.8f, 1.2f);
        shoot.Play();
    }

    public void Hit()
    {
        hit.pitch = Random.Range(0.8f, 1.2f);
        hit.Play();
    }

    public void Death()
    {
        death.Play();
    }

    public void Miss()
    {
        miss.pitch = Random.Range(0.8f, 1.2f);
        miss.Play();
    }

    //Enemies Sounds

    public void EnemyDeath()
    {
        enemyDeath.pitch = Random.Range(0.8f, 1.2f);
        enemyDeath.Play();
    }

    //Ambiance Sounds

    public void Insects()
    {
        insects.Play();
    }

    public void Burp()
    {
        burp.pitch = Random.Range(0.8f, 1.2f);
        burp.Play();
    }
}
