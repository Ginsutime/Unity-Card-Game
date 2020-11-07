using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public event Action PressedCardPlay = delegate { };

    [SerializeField] DeckTester _deckTester = null;
    [SerializeField] Button cardPlayBtn = null;

    bool isPressed = false;

    private void Start()
    {
        cardPlayBtn.onClick.AddListener(ButtonPressed);
    }

    private void Update()
    {
        DetectCardPlayed();
    }

    private void DetectCardPlayed()
    {
        // Makes sure player has selected card and played it
        if (isPressed == true && (_deckTester.onCardClick.cardSelected == 1 || 
            _deckTester.onCardClick.cardSelected == 2 || 
            _deckTester.onCardClick.cardSelected == 3))
        {
            PressedCardPlay?.Invoke();
            isPressed = false;
        }
    }

    void ButtonPressed()
    {
        isPressed = true;
    }
}
