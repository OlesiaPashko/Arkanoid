using System;
using UnityEngine;

   //Ax+By=C
public struct Line
{
    public float A;
    public float B;
    public float C;
}

public static class CollisionDetector
{
    /// <summary>
    /// Collision detection between two rectangles that are axis aligned — meaning no rotation
    /// </summary>
    /// <param name="firstObject"></param>
    /// <param name="secondObject"></param>
    /// <returns></returns>
    public static bool IsCollisionAligned(Rect firstObject, Rect secondObject)
    {
        // there is no gap between any of the 4 sides of the rectangles
        return (firstObject.x < secondObject.x + secondObject.width &&
            firstObject.x + firstObject.width > secondObject.x &&
            firstObject.y < secondObject.y + secondObject.height &&
            firstObject.y + firstObject.height > secondObject.y);
    }

    public static bool IsCollision(Rect firstObject, Rect secondObject)
    {
        return firstObject.Overlaps(secondObject, true);
    }

    public static Vector2 GetIntersectPoint(Line line1, Line line2)
    {
        float delta = line1.A * line2.B - line2.A * line1.B;

        if (delta == 0)
            throw new ArgumentException("Lines are parallel");

        float x = (line2.B * line1.C - line1.B * line2.C) / delta;
        float y = (line1.A * line2.C - line2.A * line1.C) / delta;
        return new Vector2(x, y);
    }

    static Line LineFromPoints(Vector2 point1, Vector2 point2)
    {
        float a = point2.y - point1.y;
        float b = point1.x - point2.x;
        float c = a * (point1.x) + b * (point1.y);
        return new Line { A = a, B = b, C = c };
    }

    static bool IsPointOnLine(Line line, Vector2 point, float epsilon)
    {
        return Math.Abs(line.A * point.x + line.B * point.y) < Math.Abs(line.C) + epsilon
            || Math.Abs(line.A * point.x + line.B * point.y) > Math.Abs(line.C) - epsilon;
    }
}
