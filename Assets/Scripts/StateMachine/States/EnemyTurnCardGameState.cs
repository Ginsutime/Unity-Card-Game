using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EnemyTurnCardGameState : CardGameState
{
    // Creates two hookups outside of StateMachine
    // If any 1 EnemyTurnCardGameState calls this event, all get called
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    [SerializeField] float _pauseDuration = 1.5f;
    [SerializeField] DeckTester deckTester;

    public static event Action EnemyTurnBegins;
    public static event Action EnemyTurnEnds;
    public static event Action EnemyPopOut;

    private void Start()
    {
        HealthManager.WinEventState += OnEnemyDeath;
    }

    public override void Enter()
    {
        EnemyPopOut.Invoke();

        Debug.Log("Enemy Turn: ...Enter");
        EnemyTurnBegins?.Invoke();

        EnemyTurnBegan?.Invoke();
        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Exit()
    {
        EnemyPopOut.Invoke();

        EnemyTurnEnds?.Invoke();

        NegateDamagePlayEffect._negateDamageActivated = false;
        ReflectDamagePlayEffect._damageReflected = false;
        Debug.Log("Enemy Turn: Exit...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);
        deckTester.PlayEnemyCard();
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
