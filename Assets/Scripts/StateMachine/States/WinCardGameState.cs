using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCardGameState : CardGameState
{
    public override void Enter()
    {
        SceneManager.LoadScene("WinScene");
    }

    public override void Exit()
    {
        Debug.Log("Win State: Exiting...");
    }
}
