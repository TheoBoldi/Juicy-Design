using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXLauncher : MonoBehaviour
{
    public ParticleSystem[] particles;
    public ParticleSystem[] particles_Second;
    public ParticleSystem[] particles_Third;

    public void LaunchParticles()
    {
        foreach (ParticleSystem p in particles)
            p.Play();
    }
    public void LaunchParticles_Second()
    {
        foreach (ParticleSystem p in particles_Second)
            p.Play();
    }
    public void LaunchParticles_Third()
    {
        foreach (ParticleSystem p in particles_Third)
            p.Play();
    }

    public void PlaySFX(string soundName)
    {
        SoundManager.instance.Play(soundName);
    }
}
