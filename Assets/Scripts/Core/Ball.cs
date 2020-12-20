using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    public Vector2 velocity;

    [SerializeField]
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        radius = 0.25f;
        velocity = new Vector2(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        var a = velocity* Time.deltaTime;
        transform.position += new Vector3(a.x, a.y);

        
        LineSegment collisionLine;
        if (CollisionManager.CheckCollisions(new Circle() { radius = radius, position = transform.position}, out collisionLine))
        {
            Debug.LogError("Collision");
            velocity = Force.SpecularReflection(velocity, collisionLine);
        }
    }

}
