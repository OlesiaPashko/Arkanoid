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
        var positionBefore = transform.position;
        var deltaPosition = velocity * Time.deltaTime;
        transform.position += new Vector3(deltaPosition.x, deltaPosition.y);

        
        LineSegment collisionLine;
        if (CollisionManager.CheckCollisions(ToCircle(), out collisionLine))
        {
            /*var (leftTangentStart, rightTangentStart) = GetTangentsStarts();
            var leftTargentSegment = new LineSegment(leftTangentStart, leftTangentStart + deltaPosition);
            var rightTargentSegment = new LineSegment(rightTangentStart, rightTangentStart + deltaPosition);
            List<Vector2> intersectionPoints = new List<Vector2>();
            try
            {
                intersectionPoints.Add(leftTargentSegment.GetIntersectPoint(collisionLine));
            }
            catch { }
            try
            {
                intersectionPoints.Add(rightTargentSegment.GetIntersectPoint(collisionLine));
            }
            catch { }
            var minDistance = intersectionPoints[0]-;
            var minTargetSegment = new LineAS()
            var intersectionPoint = deltaPositionLine.GetIntersectPoint(collisionLine);*/
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
