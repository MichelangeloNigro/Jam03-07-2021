using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SFX", menuName = "ScriptableObjects/SFXs", order = 1)]
public class SO_SFX : ScriptableObject
{
    public AudioClip clip;
    [Range(0, 256)]
    public int priority = 128;
    [Range(0, 1)]
    public float volume = 0.5f;
    [Range(-3, 3)]
    public float pitch = 1;
    [Range(-1, 1)]
    public float stereoPan = 0;
    [Range(0, 1)]
    public float spatialBlend = 0;
    [Range(0, 1.1f)]
    public float reverbZoneMix = 1;

    public void Play(AudioSource source)
    {
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.priority = priority;
        source.panStereo = stereoPan;
        source.spatialBlend = spatialBlend;
        source.reverbZoneMix = reverbZoneMix;
        source.Play();
    }
}