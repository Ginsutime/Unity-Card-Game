using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSrc;

    [SerializeField] AudioSource newTurn = null;
    [SerializeField] AudioSource cardDraw = null;
    [SerializeField] AudioSource cardPlace = null;
    [SerializeField] AudioSource cardSelected = null;
    [SerializeField] AudioSource cardClicked = null;
    [SerializeField] AudioSource InGame_BtnClick = null;

    private void Start()
    {
        audioSrc.volume = PlayerPrefs.GetFloat("MusicVolume");

        PlayerTurnCardGameState.NewTurn += OnNewTurn;
        DeckTester.OnPlay += OnCardPlace;
        DeckTester.OnDraw += OnCardDraw;
        OnCardClick.CardHoveredOver += OnCardSelected;
        OnCardClick.CardClicked += OnCardClicked;
    }

    void OnNewTurn()
    {
        newTurn.PlayOneShot(newTurn.clip);
    }

    void OnCardDraw()
    {
        cardDraw.PlayOneShot(cardDraw.clip);
    }

    void OnCardPlace()
    {
        cardPlace.PlayOneShot(cardPlace.clip);
    }

    void OnCardSelected()
    {
        cardSelected.PlayOneShot(cardSelected.clip);
    }

    void OnCardClicked()
    {
        cardClicked.PlayOneShot(cardClicked.clip);
    }

    public void OnInGameButtonClick()
    {
        InGame_BtnClick.PlayOneShot(InGame_BtnClick.clip);
    }
}
