using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHealPlayEffect",
    menuName = "CardData/PlayEffects/Heal")]
public class HealPlayEffect : CardPlayEffect
{
    public static bool _isHealing = false;

    [SerializeField] int _healAmount = 1;

    public override void Activate(ITargetable target)
    {
        // test to see if the target is damageable
        IDamageable objectToDamage = target as IDamageable;
        // if it is, apply damage
        if (objectToDamage != null)
        {
            _isHealing = true;
            objectToDamage.TakeDamage(_healAmount);
            Debug.Log("Add health to the target");
        }
        else
        {
            Debug.Log("Target is not healable...");
        }
    }
}
