using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDamagePlayEffect",
    menuName = "CardData/PlayEffects/Damage")]
public class DamagePlayEffect : CardPlayEffect
{
    public int _damageAmount = 1;

    public override void Activate(ITargetable target)
    {
        // test to see if the target is damageable
        IDamageable objectToDamage = target as IDamageable;
        // if it is, apply damage
        if (objectToDamage != null)
        {
            if (DoubleDamagePlayEffect._doubleDamageActivated == false && NegateDamagePlayEffect._negateDamageActivated == false)
            {
                objectToDamage.TakeDamage(_damageAmount);
                Debug.Log("Add damage to the target");
            }
            else if (DoubleDamagePlayEffect._doubleDamageActivated == true)
            {
                objectToDamage.TakeDamage(_damageAmount * DoubleDamagePlayEffect._doubleDamage);
                Debug.Log("Add damage to the target");
            }
            else if (NegateDamagePlayEffect._negateDamageActivated == true)
            {
                objectToDamage.TakeDamage(0);
                Debug.Log("Damage negated to target");
            }
        }
        else
        {
            Debug.Log("Target is not damageable...");
        }
    }
}
