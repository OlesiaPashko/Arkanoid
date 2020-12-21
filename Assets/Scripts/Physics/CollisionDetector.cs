using System;
using UnityEngine;


public static class CollisionDetector
{
    public static bool IsCollision(Rectangle firstRectangle, Rectangle secondRectangle)
    {
        LineSegment[] linesRect1 = firstRectangle.GetLines();
        LineSegment[] linesRect2 = secondRectangle.GetLines();
        foreach(var lineRect1 in linesRect1)
        {
            foreach(var lineRect2 in linesRect2)
            {
                if(lineRect1.IsCollision(lineRect2))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool IsCollision(Rectangle rect, Circle circle, out LineSegment collisionLine)
    {
        LineSegment[] segments = rect.GetLines();
        foreach (var segment in segments)
        {
            try
            {
                if (IsCollision(segment, circle))
                {
                    collisionLine = segment;
                    return true;
                }
            }
            catch
            { }
        }
        collisionLine = new LineSegment();
        return false;
    }


    public static bool IsCollision(LineSegment segment, Circle circle)
    {
        float distanceToEndPoint = (circle.position - segment.endPoint).magnitude;
        float distanceToStartPoint = (circle.position - segment.startPoint).magnitude;
        if(distanceToEndPoint < circle.radius || distanceToStartPoint < circle.radius)
        {
            return true;
        }
        var point = segment.GetProjection(circle.position);
        if(segment.IsPointOnLine(point, 0.05f) && (point-circle.position).magnitude <= circle.radius)
        {
            return true;
        }
        return false;
    }
    


}
