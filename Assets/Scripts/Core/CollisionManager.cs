using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

public class CollisionManager : MonoBehaviour
{

    [SerializeField]
    static List<BoxCollider> colliders = new List<BoxCollider>();

    [Inject]
    private GameManager gameManager;

    [Inject]
    private Field field;

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
                    colliders.Remove(collider);
                    field.RemoveGoal(collider);
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

    public bool CheckCollisions(Rectangle rectangle)
    {
        foreach (var collider in colliders)
        {
            if (CollisionDetector.IsCollision(collider.GetRectangle(), rectangle) && collider.gameObject.CompareTag("Border"))
            {
                return true;
            }
        }
        return false;
    }
}
