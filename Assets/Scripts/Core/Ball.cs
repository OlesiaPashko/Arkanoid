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
        var positionBefore = transform.position;
        var deltaPosition = velocity * Time.deltaTime;
        transform.position += new Vector3(deltaPosition.x, deltaPosition.y);

        
        LineSegment collisionLine;
        if (collisionManager.CheckCollisions(ToCircle(), out collisionLine))
        {
            transform.position = positionBefore;
            velocity = Force.SpecularReflection(velocity, collisionLine);
        }
    }

    public (Vector2, Vector2) GetTangentsStarts()
    {
        Vector2 perpendicular = Vector2.Perpendicular(velocity);
        var deltaPosition = radius * perpendicular.normalized;
        return (transform.position - (Vector3)deltaPosition, transform.position + (Vector3)deltaPosition);
    }

    private Circle ToCircle()
    {
        return new Circle() { radius = radius, position = transform.position };
    }

}
