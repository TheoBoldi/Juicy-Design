using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class JuicyLayersManager : MonoBehaviour
{

    private bool isMusicActive = false;
    private bool isSFXActive = false;
    [HideInInspector]
    public bool isAnimActive = false;
    [HideInInspector]
    public bool isShakeActive = false;
    [HideInInspector]
    public bool isScreenEffectActive = false;
    [HideInInspector]
    public bool isParticleActive = false;
    [HideInInspector]
    public bool isTrailActive = false;
    [HideInInspector]
    public bool isUIActive = false;

    public GameObject screenEffects;

    public AudioMixerGroup MusicMixer;
    public AudioMixerGroup SFXMixer;
    public AudioMixerGroup AmbientsMixer;

    public GameObject UI1;
    public GameObject UI2;

    public Font normal;
    public Font design;
    public Text score;
    private void Start()
    {
        Animator[] anims = FindObjectsOfType<Animator>();
        for (int i = 0; i < anims.Length; i++)
        {
            if (anims[i] != null && anims[i].gameObject.name != "Crade" && anims[i].gameObject.name != "Saussage")
                anims[i].enabled = isAnimActive;
        }
        ParticleSystem[] particles = FindObjectsOfType<ParticleSystem>();
        for (int i = 0; i < particles.Length; i++)
        {
            if (particles[i] != null)
            {
                if (!isParticleActive)
                    particles[i].Stop();
                else
                    particles[i].Play();
            }
        }
        TrailRenderer[] trails = FindObjectsOfType<TrailRenderer>();
        for (int i = 0; i < trails.Length; i++)
        {
            if (trails[i] != null)
            {
                if (!isParticleActive)
                {
                    trails[i].Clear();
                    trails[i].enabled = false;
                }
                else
                    trails[i].enabled = true;
            }
        }
        MusicMixer.audioMixer.SetFloat("MusicVolume", -80f);
        AmbientsMixer.audioMixer.SetFloat("AmbientsVolume", -80f);
        SFXMixer.audioMixer.SetFloat("SFXVolume", -80f);
        screenEffects.SetActive(isScreenEffectActive);
        UI1.SetActive(!isUIActive);
        UI2.SetActive(isUIActive);
    }
    public void SwitchMusic()
    {
        isMusicActive = !isMusicActive;
        if(isMusicActive)
            MusicMixer.audioMixer.SetFloat("MusicVolume", 0f);
        else
            MusicMixer.audioMixer.SetFloat("MusicVolume", -80f);
    }

    public void SwitchSFX()
    {
        isSFXActive = !isSFXActive;
        if (isSFXActive)
        {
            SFXMixer.audioMixer.SetFloat("SFXVolume", 0f);
            AmbientsMixer.audioMixer.SetFloat("AmbientsVolume", 0f);
        }
        else
        {
            SFXMixer.audioMixer.SetFloat("SFXVolume", -80f);
            AmbientsMixer.audioMixer.SetFloat("AmbientsVolume", -80f);
        }
    }

    public void SwitchAnimations()
    {
        isAnimActive = !isAnimActive;
        Animator[] anims = FindObjectsOfType<Animator>();
        for(int i = 0; i < anims.Length; i++)
        {
            if (anims[i] != null && anims[i].gameObject.name != "Crade" && anims[i].gameObject.name != "Saussage")
                anims[i].enabled = isAnimActive;
        }
    }

    public void SwitchShake()
    {
       isShakeActive = !isShakeActive;
    }

    public void SwitchScreen()
    {
        isScreenEffectActive = !isScreenEffectActive;
        screenEffects.SetActive(isScreenEffectActive);
    }
    public void SwitchParticle()
    {
        isParticleActive = !isParticleActive;
        ParticleSystem[] particles = FindObjectsOfType<ParticleSystem>();
        for (int i = 0; i < particles.Length; i++)
        {
            if (particles[i] != null)
            {
                if (!isParticleActive)
                {
                    particles[i].Clear();
                    particles[i].Stop();
                    if (particles[i].gameObject.name.Contains("Pizza_Death"))
                        Destroy(particles[i].gameObject);
                }
                else
                {
                    particles[i].Play();
                }
            }
        }
        
    }

    public void SwitchTrails()
    {
        isTrailActive = !isTrailActive;
        TrailRenderer[] trails = FindObjectsOfType<TrailRenderer>();
        for (int i = 0; i < trails.Length; i++)
        {
            if (trails[i] != null)
            {
                if (!isTrailActive)
                {
                    trails[i].Clear();
                    trails[i].enabled = false;
                }
                else
                    trails[i].enabled = true;
            }
        }
    }

    public void SwitchUI()
    {
        isUIActive = !isUIActive;
        UI1.SetActive(!isUIActive);
        UI2.SetActive(isUIActive);

        if (isUIActive)
            score.font = design;
        else
            score.font = normal;
    }
}
