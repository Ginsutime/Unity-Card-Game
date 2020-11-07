using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCardGameState : CardGameState
{
    public override void Enter()
    {
        SceneManager.LoadScene("CardTest");
    }

    public override void Exit()
    {
        Application.Quit();
    }
}
