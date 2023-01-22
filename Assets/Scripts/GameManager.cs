using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    public BallBase ballBase;

    public static GameManager Instance;
    //public StateMachine stateMachine;

    public Player[] players;

    [Header("MENUS")]
    public GameObject uiMainMenu;

    private void Awake()
    {
        Instance = this;

        players = FindObjectsOfType<Player>();
    }

    public void ResetBall()
    {
        ballBase.ResetBall();
        ballBase.CanMove(false);
        Invoke(nameof(SetBallFree), 1);
    }

    public void ResetPlayers()
    {
        foreach(var player in players)
        {
            player.ResetPlayer();
        }
    }


    private void SetBallFree()
    {
        ballBase.CanMove(true);
    }

    public void StartGame()
    {
        ballBase.CanMove(true);
    }

    public void EndGame()
    {
        //stateMachine.SwitchStates(StateMachine.States.END_GAME);
        StateMachine.Instance.SwitchEndGame();
    }


    public void ShowMainMenu()
    {
        ballBase.ResetBall();
        uiMainMenu.SetActive(true);
        ballBase.CanMove(false);
    }
}
