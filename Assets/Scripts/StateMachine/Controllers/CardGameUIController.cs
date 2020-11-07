using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameUIController : MonoBehaviour
{
    [SerializeField] Text _enemyThinkingTextUI = null;
    [SerializeField] Text _playerHealth = null;
    [SerializeField] Text _enemyHealth = null;
    [SerializeField] Text _shuffleDeck = null;

    [SerializeField] HealthManager _healthManager = null;
    [SerializeField] DeckTester _deckTester = null;

    private void OnEnable()
    {
        EnemyTurnCardGameState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded += OnEnemyTurnEnded;
    }

    private void OnDisable()
    {
        EnemyTurnCardGameState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded -= OnEnemyTurnEnded;
    }

    private void Start()
    {
        // make sure text is disabled on start
        _enemyThinkingTextUI.gameObject.SetActive(false);
        _shuffleDeck.gameObject.SetActive(false);
    }

    private void Update()
    {
        _playerHealth.text = "Player Health: " + _healthManager.playerHealth;
        _enemyHealth.text = "Enemy Health: " + _healthManager.enemyHealth;

        if (_deckTester.shuffling == true)
        {
            _shuffleDeck.gameObject.SetActive(true);
        }
        else
        {
            _shuffleDeck.gameObject.SetActive(false);
        }
    }

    void OnEnemyTurnBegan()
    {
        _enemyThinkingTextUI.gameObject.SetActive(true);
    }

    void OnEnemyTurnEnded()
    {
        _enemyThinkingTextUI.gameObject.SetActive(false);
    }
}
