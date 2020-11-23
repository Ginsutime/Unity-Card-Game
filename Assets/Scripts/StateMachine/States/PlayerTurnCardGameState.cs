using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerTurnCardGameState : CardGameState
{
    public static event Action NewTurn;
    public static event Action PlayerTurnBegins;
    public static event Action PlayerTurnEnds;
    public static event Action PlayerPopOut;

    // Logic for double damage counter
    int _turnProxy = 0;
    int _countKeeper = 1;

    public override void Enter()
    {
        PlayerPopOut?.Invoke();

        Debug.Log("Player Turn: ...Entering");

        PlayerTurnBegins?.Invoke();
        NewTurn?.Invoke();
        // hook into events
        StateMachine.Input.PressedCardPlay += OnPressedConfirm;
        HealthManager.LoseEventState += OnPlayerDeath;

        // Double damage logic
        if (_countKeeper <= _turnProxy)
        {
            Debug.LogWarning("Double damage is false");
            DoubleDamagePlayEffect._doubleDamageActivated = false;

            _countKeeper = 1;

            Debug.LogWarning("Proxy Count:" + _turnProxy);
            Debug.LogWarning("Double Damage False" + _countKeeper);
        }

        if (DoubleDamagePlayEffect._doubleDamageActivated == true)
        {
            Debug.LogWarning("Double damage is true");
            Debug.LogWarning("Double Damage Active" + _countKeeper);
            _countKeeper--;
        }
    }

    public override void Exit()
    {
        PlayerPopOut?.Invoke();

        PlayerTurnEnds?.Invoke();
        // unhook from events
        StateMachine.Input.PressedCardPlay -= OnPressedConfirm;

        Debug.Log("Player Turn: Exiting...");
    }

    void OnPressedConfirm()
    {
        Debug.Log("Attempt to enter Enemy State!");
        StateMachine.ChangeState<EnemyTurnCardGameState>();
    }

    void OnPlayerDeath()
    {
        StateMachine.ChangeState<LoseCardGameState>();
    }
}
