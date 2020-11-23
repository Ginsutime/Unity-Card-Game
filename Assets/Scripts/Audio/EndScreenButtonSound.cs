using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenButtonSound : MonoBehaviour
{
    [SerializeField] AudioSource EndGame_BtnClick = null;

    public void OnInGameButtonClick()
    {
        EndGame_BtnClick.PlayOneShot(EndGame_BtnClick.clip);
    }
}
