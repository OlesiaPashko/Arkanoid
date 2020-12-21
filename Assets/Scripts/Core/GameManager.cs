using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject]
    private Ball ball;

    [Inject]
    private Platform platform;

    [Inject]
    private Field field;

    [Inject]
    private UIManager UIManager;
    public void Lose()
    {
        UIManager.ShowLose();
        Time.timeScale = 0;
    }

    public void Win()
    {
        UIManager.ShowWin();
        Time.timeScale = 0;
    }

    public void PlayAgain()
    {
        UIManager.CloseWindows();
        Time.timeScale = 1;
        field.RespawnGoals();
        ball.SetStartValues();
        platform.MoveToStartPosition();
    }
}
