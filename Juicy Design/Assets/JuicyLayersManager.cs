using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public AudioMixerGroup MusicMixer;
    public AudioMixerGroup SFXMixer;
    public AudioMixerGroup AmbientsMixer;

    private void Start()
    {
        Animator[] anims = FindObjectsOfType<Animator>();
        for (int i = 0; i < anims.Length; i++)
        {
            if (anims[i] != null)
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
            if (anims[i] != null)
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
}
