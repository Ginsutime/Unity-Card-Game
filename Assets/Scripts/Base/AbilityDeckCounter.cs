using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDeckCounter : MonoBehaviour
{
    [SerializeField] DeckTester deckTester;
    [SerializeField] Text deckCounter;

    private void Update()
    {
        AbilityCount();
    }

    void AbilityCount()
    {
        deckCounter.text = "Cards in Deck: " + deckTester._abilityDeck.Count.ToString();
    }
}
