using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource audioSrc;
    public Slider volume;

    private void Start()
    {
        volume.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void Update()
    {
        audioSrc.volume = volume.value;
    }

    public void PlayerPrefInfo()
    {
        PlayerPrefs.SetFloat("MusicVolume", audioSrc.volume);
    }
}
