using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameMusicScript : MonoBehaviour
{    
    public static AudioClip bgm;
    public static AudioClip ambience;
    static AudioSource audio;
    Movement pitchedOrNot;

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        ambience = Resources.Load<AudioClip>("ambience");
        bgm = Resources.Load<AudioClip>("bgm");
    }

    public static void PlayGameBGM()
    {
        audio.clip = ambience;
        audio.Play();
    }
}
