using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectsSlider;
    private float backgroundFloat, soundEffectsFloat;
    public AudioSource[] backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    void Start()
    {

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {  //if it the player's first play ,start the music according to the volume slider.
            backgroundFloat = 1f;
            soundEffectsFloat = 1f;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }

    public void SaveSoundSettings()
    {   //save  the playerPrefs
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
        PlayerPrefs.Save();
    }

    private void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        //update the sounds according to the player's preference
        for (int i = 0; i < backgroundAudio.Length; i++)
        {
            backgroundAudio[i].volume = backgroundSlider.value;

        }
        for (int j = 0; j < soundEffectsAudio.Length; j++)
        {
            soundEffectsAudio[j].volume = soundEffectsSlider.value;
        }

    }
}


