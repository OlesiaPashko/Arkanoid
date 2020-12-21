using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Zenject;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    private Vector2 startPoint;

    [SerializeField]
    private float gap;

    [SerializeField]
    private int rowsCount;

    [SerializeField]
    private int columnsCount;

    public static List<BoxCollider> colliders = new List<BoxCollider>();

    [SerializeField]
    private BoxCollider goal;

    private List<BoxCollider> spawnedGoals = new List<BoxCollider>();

    [Inject]
    private GameManager gameManager;

    private void Start()
    {
        SpawnGoals();
    }

    public static void SetColliders()
    {
        Object[] objects = Resources.FindObjectsOfTypeAll(typeof(BoxCollider));
        colliders = new List<BoxCollider>();
        foreach(var obj in objects)
        {
            colliders.Add(obj as BoxCollider);
        }
    }

    public bool CheckCollisions(Circle circle, out LineSegment collisionLine)
    {
        foreach (var collider in colliders)
        {
            if (CollisionDetector.IsCollision(collider.GetRectangle(), circle, out collisionLine))
            {
                if (collider.gameObject.CompareTag("Goal"))
                {
                    RemoveGoal(collider);
                }
                else if (collider.gameObject.CompareTag("Floor"))
                {
                    gameManager.Lose();
                }
                return true;
            }
        }
        collisionLine = new LineSegment();
        return false;
    }

    public void RemoveGoal(BoxCollider goal)
    {
        spawnedGoals.Remove(goal);
        colliders.Remove(goal);
        Destroy(goal.gameObject);
        if (spawnedGoals.Count == 0)
            gameManager.Win();
    }

    public bool CheckCollisions(Rectangle rectangle)
    {
        foreach (var collider in colliders)
        {
            if (CollisionDetector.IsCollision(collider?.GetRectangle(), rectangle) && collider.gameObject.CompareTag("Border"))
            {
                return true;
            }
        }
        return false;
    }


    public void SpawnGoals()
    {
        Vector2 pointToSpawn = startPoint;
        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < columnsCount; j++)
            {
                BoxCollider spawnedGoal = Instantiate(goal, pointToSpawn, Quaternion.identity);
                pointToSpawn += new Vector2(gap, 0);
                spawnedGoals.Add(spawnedGoal);
            }
            pointToSpawn.x = startPoint.x;
            pointToSpawn += new Vector2(0, gap);
        }
    }

    public void RespawnGoals()
    {
        for(int i = 0; i < spawnedGoals.Count; i++)
        {
            var goal = spawnedGoals[i];
            if (goal.gameObject.CompareTag("Goal"))
            {
                colliders.Remove(goal);
                spawnedGoals.Remove(goal);
                i--;
                Destroy(goal.gameObject);
            }
        }
        SpawnGoals();
    }
}
