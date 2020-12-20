using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField]
    private BoxCollider goal;

    [SerializeField]
    private Vector2 startPoint;

    [SerializeField]
    private int rowsCount;

    [SerializeField]
    private int columnsCount;

    
    private List<BoxCollider> goals = new List<BoxCollider>();

    private static Field _instance;

    public static Field Instance { get { return _instance; } }

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
    void Start()
    {
        SpawnGoals();
    }

    public void SpawnGoals()
    {
        Vector2 pointToSpawn = startPoint;
        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < columnsCount; j++)
            {
                BoxCollider spawnedGoal = Instantiate(goal, pointToSpawn, Quaternion.identity);
                pointToSpawn += new Vector2(2, 0);
                goals.Add(spawnedGoal);
            }
            pointToSpawn.x = startPoint.x;
            pointToSpawn += new Vector2(0, 2);
        }
    }

    public void RespawnGoals()
    {
        foreach(var goal in goals)
        {
            Destroy(goal.gameObject);
        }
        goals = new List<BoxCollider>();
        SpawnGoals();
    }

    public void RemoveGoal(BoxCollider goal)
    {
        goals.Remove(goal);
        Destroy(goal.gameObject);
        if (goals.Count == 0)
            GameManager.Instance.Win();
    }

}
