using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTurnCardGameState : CardGameState
{
    // Creates two hookups outside of StateMachine
    // If any 1 EnemyTurnCardGameState calls this event, all get called
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    [SerializeField] float _pauseDuration = 1.5f;

    private void Start()
    {
        HealthManager.WinEventState += OnEnemyDeath;
    }

    public override void Enter()
    {
        Debug.Log("Enemy Turn: ...Enter");
        EnemyTurnBegan?.Invoke();

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("Enemy Turn: Exit...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Enemy performs action");
        EnemyTurnEnded?.Invoke();
        // Turn over. Go back to Player.
        StateMachine.ChangeState<PlayerTurnCardGameState>();
    }

    void OnEnemyDeath()
    {
        StateMachine.ChangeState<WinCardGameState>();
    }
}
