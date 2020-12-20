using System;
using UnityEngine;


public static class CollisionDetector
{

    public static bool IsCollision(Rectangle firstObject, Rectangle secondObject)
    {
        LineSegment[] linesRect1 = GetLinesFromRectangle(firstObject);
        LineSegment[] linesRect2 = GetLinesFromRectangle(secondObject);
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
        LineSegment[] segments = GetLinesFromRectangle(rect);
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
            {

            }
        }
        collisionLine = new LineSegment();
        return false;
    }
    
    public static LineSegment[] GetLinesFromRectangle(Rectangle rect)
    {
        return new LineSegment[] 
        {
            new LineSegment(rect.A, rect.B),
            new LineSegment(rect.A, rect.D),
            new LineSegment(rect.C, rect.B),
            new LineSegment(rect.C, rect.D) 
        };
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
