using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    [SerializeField]
    static List<BoxCollider> colliders = new List<BoxCollider>();


    public static void SetColliders()
    {
        Object[] objects = Resources.FindObjectsOfTypeAll(typeof(BoxCollider));
        colliders = new List<BoxCollider>();
        foreach(var obj in objects)
        {
            colliders.Add(obj as BoxCollider);
        }
        Debug.LogError("Length of colliders list = " + objects.Length);
    }

    public static bool CheckCollisions(Circle circle, out LineSegment collisionLine)
    {
        foreach (var collider in colliders)
        {
            if (CollisionDetector.IsCollision(collider.GetRectangle(), circle, out collisionLine))
            {
                if (collider.gameObject.CompareTag("Goal"))
                {
                    colliders.Remove(collider);
                    Field.Instance.RemoveGoal(collider);
                }
                else if (collider.gameObject.CompareTag("Floor"))
                {
                   // GameManager.Instance.Lose();
                }
                return true;
            }
        }
        collisionLine = new LineSegment();
        return false;
    }

    public static bool CheckCollisions(Rectangle rectangle)
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
