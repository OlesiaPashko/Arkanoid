using System;
using UnityEngine;

   //Ax+By=C
public struct Line
{
    public float A;
    public float B;
    public float C;
    public Vector2 startPoint;
    public Vector2 endPoint;
    public override string ToString()
    {
        if (B < 0)
        {
            return $"Start = {startPoint}; End = {endPoint}; Line - {A}x{B}y={C}";
        }
        else
        {
            return $"Start = {startPoint}; End = {endPoint}; Line - {A}x+{B}y={C}";
        }
    }
}

public static class CollisionDetector
{

    public static bool IsCollision(Rectangle firstObject, Rectangle secondObject)
    {
        Line[] linesRect1 = GetLinesFromRectangle(firstObject);
        Line[] linesRect2 = GetLinesFromRectangle(secondObject);
        foreach(var lineRect1 in linesRect1)
        {
            foreach(var lineRect2 in linesRect2)
            {
                if(IsCollision(lineRect1, lineRect2))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static Line[] GetLinesFromRectangle(Rectangle rect)
    {
        return new Line[] 
        {
            GetLineFromPoints(rect.A, rect.B),
            GetLineFromPoints(rect.A, rect.D),
            GetLineFromPoints(rect.C, rect.B),
            GetLineFromPoints(rect.C, rect.D) 
        };
    }

    public static bool IsCollision(Line line1, Line line2, float epsilon = 0.05f)
    {
        try
        {
            Vector2 point = GetIntersectPoint(line1, line2);
            return IsPointOnLine(line1, point, epsilon) && IsPointOnLine(line2, point, epsilon);
        }
        catch
        {
            return false;
        }
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

    public static Line GetLineFromPoints(Vector2 point1, Vector2 point2)
    {
        float a = point2.y - point1.y;
        float b = point1.x - point2.x;
        float c = a * (point1.x) + b * (point1.y);
        return new Line { A = a, B = b, C = c, startPoint = point1, endPoint = point2 };
    }

    public static bool IsPointOnLine(Line line, Vector2 point, float epsilon)
    {
        bool isOnLine = Math.Abs(line.A * point.x + line.B * point.y) < Math.Abs(line.C) + epsilon
            && Math.Abs(line.A * point.x + line.B * point.y) > Math.Abs(line.C) - epsilon;
        float maxX = line.endPoint.x > line.startPoint.x ? line.endPoint.x : line.startPoint.x;
        float minX = line.endPoint.x < line.startPoint.x ? line.endPoint.x : line.startPoint.x;
        float maxY = line.endPoint.y > line.startPoint.y ? line.endPoint.y : line.startPoint.y;
        float minY = line.endPoint.y < line.startPoint.y ? line.endPoint.y : line.startPoint.y;
        bool isInside = point.x <= maxX && point.x >= minX && point.y <= maxY && point.y >= minY;
        return isOnLine && isInside;
    }

}
