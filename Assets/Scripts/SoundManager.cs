using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public Sounds[] sounds;
    bool adIsplay;
    bool timerCheck;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sounds)
        {
            s.audio = gameObject.AddComponent<AudioSource>();
            s.audio.clip = s.clip;
            s.audio.playOnAwake = false;
            s.audio.volume = s.volume;
        }
    }

    public void Play(string name)
    {
        Sounds snd = Array.Find(sounds, s => s.name == name);
        if (snd == null)
        {
            return;
        }
        snd.audio.Play();
    }
}
