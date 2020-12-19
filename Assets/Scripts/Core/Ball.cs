using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Vector3 velocity;

    
    private float radius = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        Rectangle rect = new Rectangle() { A = new Vector2(-8f, 4.75f), B = new Vector2(-8f, 5.25f), C = new Vector2(8f, 5.25f), D = new Vector2(8f, 4.75f) };
        Line collisionLine;//= new Line() { A = 0, B = 1, C = 4.75f, startPoint = new Vector2(-8, 4.75f), endPoint = new Vector2(8, 4.75f) };
        //Vector2 intersectionPoint = CollisionDetector.GetIntersectPoint(collisionLine, velocity);
        if (CollisionDetector.IsCollision(rect, velocity, new Vector2(transform.position.x, transform.position.y), 0.25f, out collisionLine))
        {
            Debug.LogError("Collision");
            velocity = Force.SpecularReflection(velocity, collisionLine);
        }

        /*transform.position += velocity * Time.deltaTime;
        Line upperBorder = new Line { A = 0, B = 1, C = 5, startPoint = new Vector2(-8, 5), endPoint = new Vector2(8, 5) };
        Vector2 intersectionPoint = CollisionDetector.GetIntersectPoint(upperBorder, velocity);
        if ((intersectionPoint - new Vector2(transform.position.x, transform.position.y)).magnitude <= 0.25f)
        {
            velocity = Force.SpecularReflection(velocity, upperBorder);
        }*/
    }
}
