using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    //TODO build a more structured connection
    public static ITargetable CurrentTarget;
    // interfaces don't serialize, so need class reference
    [SerializeField] HealthManager _objectToTarget = null;

    // Sets the target to the health manager
    private void Start()
    {
        ITargetable possibleTarget =
    _objectToTarget.GetComponent<ITargetable>();

        CurrentTarget = possibleTarget;

        Debug.LogWarning(possibleTarget);
    }
}
