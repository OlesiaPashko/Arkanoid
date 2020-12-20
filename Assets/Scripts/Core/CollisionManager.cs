using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    [SerializeField]
    static List<BoxCollider> colliders;
    void Start()
    {
        SetColliders();
    }

    public static void SetColliders()
    {
        Object[] objects = Resources.FindObjectsOfTypeAll(typeof(BoxCollider));
        colliders = new List<BoxCollider>();
        foreach(var obj in objects)
        {
            colliders.Add(obj as BoxCollider);
        }
        Debug.LogError(objects.Length);
    }

    public static bool CheckCollisions(Circle circle, out LineSegment collisionLine)
    {
        foreach (var collider in colliders)
        {
            if (CollisionDetector.IsCollision(collider.GetRectangle(), circle, out collisionLine))
            {
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
