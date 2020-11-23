using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewReflectDamagePlayEffect",
    menuName = "CardData/PlayEffects/ReflectDamage")]
public class ReflectDamagePlayEffect : CardPlayEffect
{
    public static bool _damageReflected = false;

    public override void Activate(ITargetable target)
    {
        // test to see if the target is damageable
        IDamageable objectToDamage = target as IDamageable;
        // if it is, apply damage
        if (objectToDamage != null)
        {
            _damageReflected = true;
            Debug.Log("Damage negated for the next card dealt against player");
        }
        else
        {
            Debug.Log("Target is not damageable...");
        }
    }
}
