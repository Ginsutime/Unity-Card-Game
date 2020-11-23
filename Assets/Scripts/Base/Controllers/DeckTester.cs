using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeckTester : MonoBehaviour
{
    [SerializeField] List<AbilityCardData> _abilityDeckConfig
        = new List<AbilityCardData>();
    [SerializeField] AbilityCardView _abilityCardView = null;
    public Deck<AbilityCard> _abilityDeck = new Deck<AbilityCard>();
    Deck<AbilityCard> _abilityDiscard = new Deck<AbilityCard>();
    Deck<AbilityCard> _playerHand = new Deck<AbilityCard>();

    [SerializeField]
    List<AbilityCardData> _enemyDeckConfig
    = new List<AbilityCardData>();
    Deck<AbilityCard> _enemyDamageHand = new Deck<AbilityCard>();

    public OnCardClick onCardClick;
    public bool gameStarted = false;

    public bool cooldown = false;
    public bool shuffling = false;

    public static event Action OnPlay;
    public static event Action OnDraw;

    private void Start()
    {
        SetupAbilityDeck();
        SetupEnemyAbilityDeck();
    }

    private void SetupAbilityDeck()
    {
        foreach(AbilityCardData abilityData in _abilityDeckConfig)
        {
            AbilityCard newAbilityCard = new AbilityCard(abilityData);
            _abilityDeck.Add(newAbilityCard);
        }

        _abilityDeck.Shuffle();
    }

    private void SetupEnemyAbilityDeck()
    {
        foreach (AbilityCardData abilityData in _enemyDeckConfig)
        {
            AbilityCard newAbilityCard = new AbilityCard(abilityData);
            _enemyDamageHand.Add(newAbilityCard);
        }

        _enemyDamageHand.Shuffle();
    }

    public void InitialDraw(int cardNumber)
    {
        AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + newCard.Name);
        _playerHand.Add(newCard, DeckPosition.Top);
        _abilityCardView.emptyCheck = false; // Removes issues with boolean check
        _abilityCardView.DisplayCard1(newCard);

        AbilityCard newCard2 = _abilityDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + newCard2.Name);
        _playerHand.Add(newCard2, DeckPosition.Top);
        _abilityCardView.emptyCheck = false; // Removes issues with boolean check
        _abilityCardView.DisplayCard2(newCard2);

        AbilityCard newCard3 = _abilityDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + newCard3.Name);
        _playerHand.Add(newCard3, DeckPosition.Top);
        _abilityCardView.emptyCheck = false; // Removes issues with boolean check
        _abilityCardView.DisplayCard3(newCard3);

        _playerHand.Display();
    }

    public void Draw()
    {
        if (_abilityDeck.IsEmpty)
        {
            ShuffleOnEmpty();

            Debug.Log("Shuffling on empty.");
        }

        // Check to limit amount of cards drawn into hand
        if (_playerHand.Count < 3)
        {
            AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
            Debug.Log("Drew card: " + newCard.Name);
            _playerHand.Add(newCard, DeckPosition.Top);

            if (onCardClick.cardSelected == 1)
            {
                _abilityCardView.emptyCheck = false; // Removes issues with boolean check
            }
            else if (onCardClick.cardSelected == 2)
            {
                _abilityCardView.emptyCheck = false; // Removes issues with boolean check
            }
            else if (onCardClick.cardSelected == 3)
            {
                _abilityCardView.emptyCheck = false; // Removes issues with boolean check
            }

            _abilityCardView.DisplayCard1(_playerHand.GetCard(0));
            _abilityCardView.DisplayCard2(_playerHand.GetCard(1));
            _abilityCardView.DisplayCard3(_playerHand.GetCard(2));

            OnDraw?.Invoke();
        }
        else
        {
            // Null check
            Debug.Log("Null check");
        }
    }

    public void PlayTopCard()
    {
        if (_playerHand.Count == 0 || cooldown == true)
        {
            Debug.LogWarning("Null check for cooldown and count");
            // Check to remove argument out of range exception error
        }
        else
        {
            Debug.LogWarning("Working Overall");
            _playerHand.Display();
            gameStarted = true;

            Invoke("ResetCooldown", 1.6f);
            cooldown = true;

            OnPlay?.Invoke();

            if (onCardClick.cardSelected == 1)
            {
                Debug.LogWarning("Working1A");
                int tempnumber = onCardClick.cardSelected;
                AbilityCard targetCard = _playerHand.GetCard(tempnumber - 1);
                targetCard.Play();
                // TODO consider expanding Remove to accept deck position
                _playerHand.Remove(tempnumber - 1);
                _abilityDiscard.Add(targetCard);
                _abilityCardView.DisplayDiscard(targetCard);
                Debug.Log("Card added to discard: " + targetCard.Name);


                // Removes card from hand -> So empty
                _abilityCardView.emptyCheck = true;
                _abilityCardView.DisplayCard1(targetCard);
                Debug.LogWarning("Card added to display: " + targetCard.Name);
            }
            else if (onCardClick.cardSelected == 2)
            {
                Debug.LogWarning("Working2A");
                int tempnumber = onCardClick.cardSelected;
                AbilityCard targetCard = _playerHand.GetCard(tempnumber - 1);
                targetCard.Play();
                // TODO consider expanding Remove to accept deck position
                _playerHand.Remove(tempnumber - 1);
                _abilityDiscard.Add(targetCard);
                _abilityCardView.DisplayDiscard(targetCard);
                Debug.Log("Card added to discard: " + targetCard.Name);

                // Removes card from hand -> So empty
                _abilityCardView.emptyCheck = true;
                _abilityCardView.DisplayCard2(targetCard);
                Debug.LogWarning("Card added to display: " + targetCard.Name);
            }
            else if (onCardClick.cardSelected == 3)
            {
                Debug.LogWarning("Working3A");
                int tempnumber = onCardClick.cardSelected;
                AbilityCard targetCard = _playerHand.GetCard(tempnumber - 1);
                targetCard.Play();
                // TODO consider expanding Remove to accept deck position
                _playerHand.Remove(tempnumber - 1);
                _abilityDiscard.Add(targetCard);
                _abilityCardView.DisplayDiscard(targetCard);
                Debug.LogWarning("Card added to discard: " + targetCard.Name);

                // Removes card from hand -> So empty
                _abilityCardView.emptyCheck = true;
                _abilityCardView.DisplayCard3(targetCard);
                Debug.LogWarning("Card added to display: " + targetCard.Name);
            }
        }

        // Internal way of drawing card since no need for player to do so
        Invoke("Draw", 1.5f);
    }

    public void PlayEnemyCard()
    {
        AbilityCard targetCard = _enemyDamageHand.GetCard(UnityEngine.Random.Range(1, 8));
        targetCard.Play();
        Debug.LogError("THIS WQORKS");
    }

    // Moves cards from discard pile to ability deck and uses Deck's Shuffle
    // Called in Draw above while IsEmpty and does logic for shuffle text bool
    void ShuffleOnEmpty()
    {
        shuffling = true;
        Invoke("ResetShuffle", 1f);

        for (int currentIndex = _abilityDiscard.Count; currentIndex > 0; --currentIndex)
        {
            AbilityCard targetCard = _abilityDiscard.TopItem;
            _abilityDiscard.Remove(_abilityDiscard.LastIndex);
            _abilityDeck.Add(targetCard);
        }
        _abilityDeck.Shuffle();
    }

    // Restricts player from being able to spam the play card btn
    void ResetCooldown()
    {
        cooldown = false;
    }

    // Turns shuffle text on and off when needed
    void ResetShuffle()
    {
        shuffling = false;
    }
}
