using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField]
    public Vector2 velocity;

    [SerializeField]
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        radius = 0.25f;
        velocity = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        var a = velocity* Time.deltaTime;
        transform.position += new Vector3(a.x, a.y);

        
        Line collisionLine;
        if (CollisionManager.CheckCollisions(this, out collisionLine))
        {
            Debug.LogError("Collision");
            velocity = Force.SpecularReflection(velocity, collisionLine);
        }
    }

    public bool IsCollision(Rectangle rect, Vector2 velocity, Vector2 currentPosition, float radius, out Line collisionLine)
    {

        Line[] lines = CollisionDetector.GetLinesFromRectangle(rect);
        foreach (var line in lines)
        {
            try
            {
                if ((CollisionDetector.GetIntersectPoint(line, velocity) - currentPosition).magnitude <= radius)
                {
                    collisionLine = line;
                    return true;
                }
            }
            catch
            {

            }
        }
        collisionLine = new Line();
        return false;
    }
}
