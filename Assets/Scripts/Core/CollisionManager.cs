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
    }

    [MenuItem("Example/Hierarchy Window Changed")]
    static void Example()
    {
        EditorApplication.hierarchyWindowChanged += SetColliders;
    }

    public static bool CheckCollisions(Circle circle, out Line collisionLine)
    {
        foreach (var collider in colliders)
        {
            if (CollisionDetector.IsCollision(collider.GetRectangle(),
                circle.velocity, new Vector2(circle.transform.position.x, circle.transform.position.y), circle.radius, out collisionLine))
            {
                return true;
            }
        }
        collisionLine = new Line();
        return false;
    }
}
