using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioSettings : MonoBehaviour
{

    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private float backgroundFloat, soundEffectsFloat;
    public AudioSource[] backgroundAudio;
    public AudioSource[] soundEffectsAudio;


    void Awake()
    {
        ContinueSettings();
    }
    private void ContinueSettings()
    { //call the playerprefs
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

        for (int i = 0; i < backgroundAudio.Length; i++)
        {
            backgroundAudio[i].volume = backgroundFloat;
        }

        for (int j = 0; j < soundEffectsAudio.Length; j++)
        {
            soundEffectsAudio[j].volume = soundEffectsFloat;
        }

    }
}
