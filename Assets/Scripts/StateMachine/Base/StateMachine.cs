using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;
    protected bool InTransition { get; private set; }

    State _currentState;
    protected State _previousState;

    public void ChangeState<T>() where T : State
    {
        T targetState = GetComponent<T>();
        if (targetState == null)
        {
            Debug.LogWarning("Cannot change to state, as it " +
                "does not exist on the State Machine Object." +
                " Make sure you have the desired State attached " +
                "to the State Machine!");
            return;
        }
        // otherwise, we found our state
        InitiateStateChange(targetState);
    }

    public void RevertState()
    {
        if (_previousState != null)
        {
            InitiateStateChange(_previousState);
        }
    }

    void InitiateStateChange(State targetState)
    {
        // if our new state is different and we're not transitioning, do it
        if (_currentState != targetState && !InTransition)
        {
            Transition(targetState);
        }
    }

    void Transition(State newState)
    {
        // start transition
        InTransition = true;
        // transitioning
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
        // end transition
        InTransition = false;
    }

    private void Update()
    {
        // simulate Update in States with 'tick'
        if (CurrentState != null && !InTransition)
        {
            CurrentState.Tick();
        }
    }
}
