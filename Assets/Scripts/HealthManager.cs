using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthManager : MonoBehaviour, ITargetable, IDamageable
{
    public int enemyHealth = 20;
    public int playerHealth = 20;

    public static event Action LoseEventState;
    public static event Action WinEventState;

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

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        Debug.Log("Took damage. Remaining health: " + enemyHealth);

        if (enemyHealth <= 0)
        {
            WinEventState?.Invoke();
        }
    }
}
