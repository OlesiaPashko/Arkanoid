using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject losePanel;

    [SerializeField]
    private GameObject winPanel;

    public void ShowLose()
    {
        losePanel.SetActive(true);
    }

    public void ShowWin()
    {
        winPanel.SetActive(true);
    }

    public void CloseWindows()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }
}
