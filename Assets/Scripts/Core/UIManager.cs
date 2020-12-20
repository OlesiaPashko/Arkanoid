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

    private static UIManager _instance;

    public static UIManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

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
