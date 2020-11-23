using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonSound : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource = null;
    [SerializeField] AudioClip _btnPress1 = null;
    [SerializeField] AudioClip _btnPress2 = null;

    public void OnClick()
    {
        int randomRange = Random.Range(1, 2);

        if (randomRange == 1)
        {
            _audioSource.clip = _btnPress1;
        }
        else
        {
            _audioSource.clip = _btnPress2;
        }

        _audioSource.pitch = Random.Range(0.75f, 1.25f);
        _audioSource.Play();
    }
}
