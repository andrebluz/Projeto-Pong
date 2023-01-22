using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME
    }

    public Dictionary<States, StateBase> dictionaryState;
    private StateBase _currentState;
    public float timeToStartGame = 1f;

    public static StateMachine Instance;

    private void Awake()
    {
        Instance = this;

        dictionaryState = new Dictionary<States, StateBase>();
        dictionaryState.Add(States.MENU, new StateBase());
        dictionaryState.Add(States.PLAYING, new StatePlaying());
        dictionaryState.Add(States.RESET_POSITION, new StateResetPosition());
        dictionaryState.Add(States.END_GAME, new StateEndGame());

        SwitchStates(States.MENU);
    }

    private void SwitchStates(States state)
    {
        if (_currentState != null)
        {
            _currentState.OnStateExit();
        }

        _currentState = dictionaryState[state];

        if (_currentState != null) _currentState.OnStateEnter();
    }

    private void Update()
    {
        if (_currentState != null)
        {
            _currentState.OnStateStay();
        }

         if (Input.GetKeyDown(KeyCode.O))
         {
            SwitchStates(States.PLAYING);
         }
    }

    public void ResetPosition()
    {
        SwitchStates(States.RESET_POSITION);
        Debug.Log("troca estado");
    }

    public void SwitchEndGame()
    {
        SwitchStates(States.END_GAME);
    }
}