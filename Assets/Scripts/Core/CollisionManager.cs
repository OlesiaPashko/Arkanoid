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

    private static void SetColliders()
    {
        Object[] objects = Resources.FindObjectsOfTypeAll(typeof(BoxCollider));
        colliders = new List<BoxCollider>();
        foreach(var obj in objects)
        {
            colliders.Add(obj as BoxCollider);
        }
        Debug.LogError(objects.Length);
    }

    [MenuItem("Example/Hierarchy Window Changed")]
    static void Example()
    {
        EditorApplication.hierarchyWindowChanged += SetColliders;
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
                Debug.LogError(collider.gameObject.tag);
                return true;
            }
        }
        return false;
    }
}
