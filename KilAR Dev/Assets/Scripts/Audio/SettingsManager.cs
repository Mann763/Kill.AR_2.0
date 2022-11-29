using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] string volumepara = "Master";
    [SerializeField] AudioMixer mastermixer;
    [SerializeField] Slider MasterSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider BGMSlider;
    [SerializeField] float multiplier = 30f;
    public static float volume;

    public void masterVolume(Slider  volume)
    {
        mastermixer.SetFloat("Master", volume.value);
        PlayerPrefs.SetFloat("Master Volume", volume.value);
        
    }

    public void SFXVolume(Slider volume)
    {
        
        mastermixer.SetFloat("SFX", volume.value);
        PlayerPrefs.SetFloat("SFX Volume", volume.value);
    }

    public void BGMVolume(Slider volume)
    {
        mastermixer.SetFloat("BGM", volume.value);
        PlayerPrefs.SetFloat("BGM Volume", volume.value);
    }

    public void Update()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("Master Volume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX Volume");
        BGMSlider.value = PlayerPrefs.GetFloat("BGM Volume");
    }
}
