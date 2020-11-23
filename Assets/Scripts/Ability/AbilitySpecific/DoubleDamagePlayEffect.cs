using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDoubleDamagePlayEffect",
    menuName = "CardData/PlayEffects/DoubleDamage")]
public class DoubleDamagePlayEffect : CardPlayEffect
{
    public static int _doubleDamage = 2;
    public static bool _doubleDamageActivated = false;

    public override void Activate(ITargetable target)
    {
        // test to see if the target is damageable
        IDamageable objectToDamage = target as IDamageable;
        // if it is, apply damage
        if (objectToDamage != null)
        {
            _doubleDamageActivated = true;
            Debug.Log("Add double damage to the next card");
        }
        else
        {
            Debug.Log("Target is not damageable...");
        }
    }
}
