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
    private UIManager UIManager;

    [Inject]
    private CollisionManager collisionManager;
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
        ball.SetStartValues();
        platform.MoveToStartPosition();
        collisionManager.RespawnGoals();
    }
}
