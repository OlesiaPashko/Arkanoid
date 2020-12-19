using System;
using UnityEngine;


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

    public static bool IsCollision(Rectangle rect, Vector2 velocity)
    {
        Line[] lines = GetLinesFromRectangle(rect);
        foreach (var line in lines)
        {
            if (IsCollision(line, velocity))
            {
                return true;
            }
        }
        return false;
    }

    public static bool IsCollision(Rectangle rect, Vector2 velocity, Vector2 currentPosition, float radius, out Line collisionLine)
    {
        Line[] lines = GetLinesFromRectangle(rect);
        foreach (var line in lines)
        {
            try
            {
                if ((GetIntersectPoint(line, velocity) - currentPosition).magnitude <= radius)
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

    public static bool IsCollision(Line line1, Vector2 velocity, float epsilon = 0.05f)
    {
        try
        {
            Vector2 point = GetIntersectPoint(line1, velocity);
            return IsPointOnLine(line1, point, epsilon);
        }
        catch
        {
            return false;
        }
    }

    public static Vector2 GetIntersectPoint(Line line1, Vector2 velocity)
    {
        Line line2 = GetLineFromPoints(new Vector2(0, 0), velocity);
        return GetIntersectPoint(line1, line2);
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
        float maxX, minX, maxY, minY;
        if (line.endPoint.x > line.startPoint.x) 
        {
            maxX = line.endPoint.x;
            minX = line.startPoint.x;
        }
        else
        {
            maxX = line.startPoint.x;
            minX = line.endPoint.x;
        }
        if(line.endPoint.y > line.startPoint.y)
        {
            maxY = line.endPoint.y;
            minY = line.startPoint.y;
        }
        else
        {
            maxY = line.startPoint.y;
            minY = line.endPoint.y;
        }
        bool isInside = point.x <= maxX && point.x >= minX && point.y <= maxY && point.y >= minY;
        return isOnLine && isInside;
    }



}
