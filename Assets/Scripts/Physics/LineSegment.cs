using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct LineSegment
{
    public Vector2 startPoint;
    public Vector2 endPoint;

    public LineSegment(Vector2 startPoint, Vector2 endPoint)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;

    }


    /// <summary>
    /// Get Ax+By=C line coefs (A, B, C) 
    /// </summary>
    /// <returns></returns>
    public (float, float, float) GetCoefs()
    {
        float A = endPoint.y - startPoint.y;
        float B = startPoint.x - endPoint.x;
        float C = A * (startPoint.x) + B * (startPoint.y);
        return (A, B, C);
    }

    public override string ToString()
    {
        var (A, B, C) = GetCoefs();
        if (B < 0)
        {
            return $"Start = {startPoint}; End = {endPoint}; Line - {A}x{B}y={C}";
        }
        else
        {
            return $"Start = {startPoint}; End = {endPoint}; Line - {A}x+{B}y={C}";
        }
    }

    public Vector2 GetVector()
    {
        var (A, B, C) = GetCoefs();
        return new Vector2(B, -A).normalized;
    }

    public Vector2 GetNormalVector()
    {
        var (A, B, C) = GetCoefs();
        return new Vector2(A, B).normalized;
    }

    public Vector2 GetIntersectPoint(LineSegment segment)
    {
        var (A1, B1, C1) = GetCoefs();
        var (A2, B2, C2) = segment.GetCoefs();

        float delta = A1 * B2 - A2 * B1;

        if (delta == 0)
            throw new ArgumentException("Lines are parallel");

        float x = (B2 * C1 - B1 * C2) / delta;
        float y = (A1 * C2 - A2 * C1) / delta;
        return new Vector2(x, y);
    }

    public bool IsPointOnLine(Vector2 point, float epsilon)
    {
        var distanceFromStartToPoint = (point - startPoint).magnitude;
        var distanceFromEndToPoint = (point - endPoint).magnitude;
        var length = GetLength();
        if (Math.Abs(distanceFromEndToPoint + distanceFromStartToPoint - length) < epsilon)
            return true;
        return false;

    }

    public float GetLength()
    {
        return (startPoint - endPoint).magnitude;
    }

    public bool IsCollision(LineSegment line, float epsilon = 0.05f)
    {
        try
        {
            Vector2 point = GetIntersectPoint(line);
            return IsPointOnLine(point, epsilon) && line.IsPointOnLine(point, epsilon);
        }
        catch
        {
            return false;
        }
    }

    public Vector2 GetProjection(Vector2 point)
    {
        var vector1 = point - startPoint;
        var vector2 = endPoint - startPoint;
        var projectionVector = Vector3.Project(vector1, vector2);
        return projectionVector + new Vector3(startPoint.x, startPoint.y);
    }
}
