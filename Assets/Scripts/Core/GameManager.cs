using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Lose()
    {
        UIManager.Instance.ShowLose();
        Time.timeScale = 0;
    }

    public void Win()
    {
        UIManager.Instance.ShowWin();
        Time.timeScale = 0;
    }
}
