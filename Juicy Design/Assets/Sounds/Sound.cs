using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public string name;
    public AudioMixerGroup mixer;

    [Range(0.1f, 1f)]
    public float pitch = 1.0f;
    [Range(0.1f, 3.0f)]
    public float volume = 1.0f;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
