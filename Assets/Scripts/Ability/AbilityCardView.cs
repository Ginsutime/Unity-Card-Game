using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCardView : MonoBehaviour
{
    [SerializeField] Text _nameTextUI = null;
    [SerializeField] Text _costTextUI = null;
    [SerializeField] Image _graphicUI = null;

    [SerializeField] Text _nameTextUI2 = null;
    [SerializeField] Text _costTextUI2 = null;
    [SerializeField] Image _graphicUI2 = null;

    [SerializeField] Text _nameTextUI3 = null;
    [SerializeField] Text _costTextUI3 = null;
    [SerializeField] Image _graphicUI3 = null;

    [SerializeField] Text _nameTextUI4 = null;
    [SerializeField] Text _costTextUI4 = null;
    [SerializeField] Image _graphicUI4 = null;

    public bool emptyCheck = false;

    public void DisplayCard1(AbilityCard abilityCard)
    {
        // Sets the card to empty based on logic in DeckTester
        if (emptyCheck == false)
        {
            _nameTextUI.text = abilityCard.Name;
            _costTextUI.text = abilityCard.Cost.ToString();
            _graphicUI.sprite = abilityCard.Graphic;
        }
        else
        {
            _nameTextUI.text = "";
            _costTextUI.text = "";
            _graphicUI.sprite = null;
        }
    }

    public void DisplayCard2(AbilityCard abilityCard)
    {
        // Sets the card to empty based on logic in DeckTester
        if (emptyCheck == false)
        {
            _nameTextUI2.text = abilityCard.Name;
            _costTextUI2.text = abilityCard.Cost.ToString();
            _graphicUI2.sprite = abilityCard.Graphic;
        }
        else
        {
            _nameTextUI2.text = "";
            _costTextUI2.text = "";
            _graphicUI2.sprite = null;
        }
    }

    public void DisplayCard3(AbilityCard abilityCard)
    {
        // Sets the card to empty based on logic in DeckTester
        if (emptyCheck == false)
        {
            _nameTextUI3.text = abilityCard.Name;
            _costTextUI3.text = abilityCard.Cost.ToString();
            _graphicUI3.sprite = abilityCard.Graphic;
        }
        else
        {
            _nameTextUI3.text = "";
            _costTextUI3.text = "";
            _graphicUI3.sprite = null;
        }
    }

    public void DisplayDiscard(AbilityCard abilityCard)
    {
        _nameTextUI4.text = abilityCard.Name;
        _costTextUI4.text = abilityCard.Cost.ToString();
        _graphicUI4.sprite = abilityCard.Graphic;
    }
}
