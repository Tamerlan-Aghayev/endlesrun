using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] Audio[] sounds;
    [SerializeField]
    Audio[] backgroundMusic;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource musicSource;

    public void PlayAudioSound(int index)
    {
        audioSource.PlayOneShot(sounds[index].clip);
    }

    public void PlayBackgroundMusic(int index)
    {
        musicSource.PlayOneShot(backgroundMusic[index].clip);
    }
}


[Serializable]
public struct Audio
{
    public string name;
    public AudioClip clip;
}