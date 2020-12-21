using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Ball : MonoBehaviour
{

    [SerializeField]
    public Vector2 velocity;

    [SerializeField]
    public float radius;

    [SerializeField]
    Vector2 startPosition;

    [Inject]
    private CollisionManager collisionManager;

    void Start()
    {
        SetStartValues();
    }

    public void SetStartValues()
    {
        transform.position = startPosition;
        radius = 0.25f;
        velocity = new Vector2(4, 8);
    }

    // Update is called once per frame
    void Update()
    {
        var previousPosition = Move();

        LineSegment collisionLine;
        if (collisionManager.CheckCollisions(ToCircle(), out collisionLine))
        {
            transform.position = previousPosition;
            velocity = Force.SpecularReflection(velocity, collisionLine);
        }
    }

    private Vector2 Move()
    {
        var previousPosition = transform.position;
        var deltaPosition = velocity * Time.deltaTime;
        transform.position += new Vector3(deltaPosition.x, deltaPosition.y);
        return previousPosition;
    }


    private Circle ToCircle()
    {
        return new Circle(radius, transform.position);
    }

}
