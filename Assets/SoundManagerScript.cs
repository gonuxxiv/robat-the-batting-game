using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip batHitSound;
    public static AudioClip ambience;
    public static AudioClip pitchingMachine;
    public static AudioClip chargingSound;
    public static AudioClip ventAirSound;
    public static AudioClip clickSound;
    public static AudioClip batterySound;
    public static AudioClip batteryCharged;
    public static AudioClip bgm;
    static AudioSource audiosrc;

    void Start()
    {
        batHitSound = Resources.Load<AudioClip>("metalbat");
        ambience = Resources.Load<AudioClip>("ambience");
        pitchingMachine = Resources.Load<AudioClip>("pitchingMachine");
        chargingSound = Resources.Load<AudioClip>("chargingSound2");
        ventAirSound = Resources.Load<AudioClip>("ventair2");
        clickSound = Resources.Load<AudioClip>("ClickSound");
        batterySound = Resources.Load<AudioClip>("batteryUsed");
        batteryCharged = Resources.Load<AudioClip>("batteryCharged2");
        bgm = Resources.Load<AudioClip>("bgm");

        audiosrc = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "metalbat":
                audiosrc.PlayOneShot(batHitSound);
                break;
            case "pitchingMachine":
                audiosrc.PlayOneShot(pitchingMachine);
                break;
            case "chargingSound":
                audiosrc.PlayOneShot(chargingSound);
                break;
            case "ventair":
                audiosrc.PlayOneShot(ventAirSound);
                break;
            case "clickSound":
                audiosrc.PlayOneShot(clickSound);
                break;
            case "ballhop":
                audiosrc.PlayOneShot(batteryCharged);
                break;
        }
    }
}
