using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXLauncher : MonoBehaviour
{
    public ParticleSystem[] particles;

    public void LaunchParticles()
    {
        foreach (ParticleSystem p in particles)
            p.Play();
    }

    public void PlaySFX(string soundName)
    {
        SoundManager.instance.Play(soundName);
    }
}
