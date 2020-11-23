using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthManager : MonoBehaviour, ITargetable, IDamageable
{
    public int enemyHealth = 50;
    public int playerHealth = 50;

    public static event Action LoseEventState;
    public static event Action WinEventState;

    [SerializeField] StateMachine stateMachine;
    [SerializeField] PlayerTurnCardGameState playerTurnCardGameState;
    [SerializeField] EnemyTurnCardGameState enemyTurnCardGameState;

    void PlayerDamage(int dmg)
    {
        //dmg = _damagePlayEffect._damageAmount;
        playerHealth -= dmg;
    }

    public void PlayerKill()
    {
        // TEMP - REMOVE LATER
        PlayerDamage(30);
        Debug.Log("Took damage. Remaining health: " + playerHealth);

        if (playerHealth <= 0)
        {
            Debug.Log("LoseEventState");
            LoseEventState?.Invoke();
        }
    }

    public void Target()
    {
        Debug.Log("HealthManager was successfully assigned as the target");
    }

    public void TakeDamage(int amount)
    {
        if (stateMachine.CurrentState == playerTurnCardGameState)
        {
            if (HealPlayEffect._isHealing == false) // If not healing, then damage card
            {
                enemyHealth -= amount;
                Debug.Log("Took damage. Remaining health: " + enemyHealth);
            }
            else
            { //  Else it is healing card
                if (playerHealth <= 50 || playerHealth > 50)
                {
                    playerHealth = Mathf.Clamp(playerHealth, 0, 50);
                    playerHealth += amount;

                    Debug.Log(playerHealth = Mathf.Clamp(playerHealth, 0, 50));
                    Debug.Log("Took healing. Remaining health: " + playerHealth);
                    HealPlayEffect._isHealing = false;
                }
            }

            if (enemyHealth <= 0)
            {
                WinEventState?.Invoke();
            }
        }
        else if (stateMachine.CurrentState == enemyTurnCardGameState)
        {
            if (ReflectDamagePlayEffect._damageReflected == false && DoubleDamagePlayEffect._doubleDamageActivated == false)
            {
                playerHealth -= amount;
                Debug.Log("Took damage. Remaining health: " + playerHealth);
            }
            else if (ReflectDamagePlayEffect._damageReflected == true && DoubleDamagePlayEffect._doubleDamageActivated == false)
            {
                enemyHealth -= amount;
                Debug.Log("Damage reflected to enemy. Remaining enemy health: " + enemyHealth);
            }
            else if (DoubleDamagePlayEffect._doubleDamageActivated == true && ReflectDamagePlayEffect._damageReflected == false)
            {
                playerHealth -= (amount / 2);
                Debug.Log("Double Damage removed from enemy dmg number (# / 2): Base # = " + amount / 2);
            }
            else
            {
                playerHealth -= (amount / 2);
                Debug.Log("Double Damage removed from enemy dmg number (# / 2): Base # = " + amount / 2);
            }

            if (playerHealth <= 0)
            {
                LoseEventState?.Invoke();
            }
        }
    }
}
