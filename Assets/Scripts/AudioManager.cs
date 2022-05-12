using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : SingletonDDOl<AudioManager>
{

    public AudioSource source;
    public AudioMixer mixer;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void PlayMusic(SO_SFX sfx,float lerpVelocity)
    {
        if (!source.isPlaying)
        {
            source.volume = sfx.volume;
            source.pitch = sfx.pitch;
            source.panStereo = sfx.stereoPan;
            source.priority = sfx.priority;
            source.spatialBlend = sfx.spatialBlend;
            source.reverbZoneMix = sfx.reverbZoneMix;
            source.clip = sfx.clip;
            source.Play();
        }
        else {
            StartCoroutine(FadeMusic(source, sfx.clip,lerpVelocity));
        }
    }
    private IEnumerator FadeMusic(AudioSource source, AudioClip newAudioClip,float lerpVelocity)
    {
        float originalVolume = 0.1f;

        yield return FadeTo(source, 0,lerpVelocity);

        source.Stop();
        source.clip = newAudioClip;
        source.Play();

        yield return FadeTo(source, originalVolume,lerpVelocity);
    }


    private IEnumerator FadeTo(AudioSource source, float value,float lerpVelocity)
    {
        while (Mathf.Abs(source.volume - value) > 0.01)
        {
            source.volume = Mathf.Lerp(source.volume, value,lerpVelocity);
            yield return null;
        }

        source.volume = value;
        source.mute = false;
    }
    public void ChangeVolume(float i) {
        mixer.SetFloat("Volume", i);
    }
}



