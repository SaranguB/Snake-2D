using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance;

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    public SoundType[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
    }

    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(sounds, i => i.soundType == sound);

        if (item != null)
            return item.soundClip;
        return null;

    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}


public enum Sounds
{
    MUSIC,
    GAME_FINISHED,
    POWERUP_SOUND,
    DEATH_SOUND,

}