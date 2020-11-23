using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNegateDamagePlayEffect",
    menuName = "CardData/PlayEffects/NegateDamage")]
public class NegateDamagePlayEffect : CardPlayEffect
{
    public static bool _negateDamageActivated = false;

    public override void Activate(ITargetable target)
    {
        // test to see if the target is damageable
        IDamageable objectToDamage = target as IDamageable;
        // if it is, apply damage
        if (objectToDamage != null)
        {
            _negateDamageActivated = true;
            Debug.Log("Damage negated for the next card dealt against player");
        }
        else
        {
            Debug.Log("Target is not damageable...");
        }
    }
}
