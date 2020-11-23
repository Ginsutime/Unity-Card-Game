using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Turn_PopUpMenu : MonoBehaviour
{
    [SerializeField] Text _enemyTurnTextUI = null;
    [SerializeField] Text _playerTurnTextUI = null;
    [SerializeField] GameObject _popOutPanel1 = null;
    [SerializeField] GameObject _popOutPanel2 = null;

    int _enemyTurnCount = 0;
    int _playerTurnCount = 0;

    private void Start()
    {
        PlayerTurnCardGameState.PlayerTurnBegins += OnPlayerTurnStart;
        PlayerTurnCardGameState.PlayerTurnEnds += OnPlayerTurnEnd;
        EnemyTurnCardGameState.EnemyTurnBegins += OnEnemyTurnStart;
        EnemyTurnCardGameState.EnemyTurnEnds += OnEnemyTurnEnd;

        PlayerTurnCardGameState.PlayerPopOut += OpenPlayerPanel;
        EnemyTurnCardGameState.EnemyPopOut += OpenEnemyPanel;
    }

    void OpenPlayerPanel()
    {
        if (_popOutPanel1 != null)
        {
            Animator animator = _popOutPanel1.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("isPlayerActive");

                animator.SetBool("isPlayerActive", !isOpen);
            }
        }
    }

    void OpenEnemyPanel()
    {
        if (_popOutPanel2 != null)
        {
            Animator animator = _popOutPanel2.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("isEnemyActive");

                animator.SetBool("isEnemyActive", !isOpen);
            }
        }
    }

    void OnPlayerTurnStart()
    {
        _playerTurnTextUI.gameObject.SetActive(true);
        _playerTurnCount++;
        _playerTurnTextUI.text = _playerTurnCount.ToString();
    }

    void OnPlayerTurnEnd()
    {
        _playerTurnTextUI.gameObject.SetActive(false);
    }

    void OnEnemyTurnStart()
    {
        _enemyTurnTextUI.gameObject.SetActive(true);
        _enemyTurnCount++;
        _enemyTurnTextUI.text = _enemyTurnCount.ToString();
    }

    void OnEnemyTurnEnd()
    {
        _enemyTurnTextUI.gameObject.SetActive(false);
    }
}
