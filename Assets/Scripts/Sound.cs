using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sounds
{
    public string name;
    public float volume;
    public AudioClip clip;
    [HideInInspector]
    public AudioSource audio;

}
