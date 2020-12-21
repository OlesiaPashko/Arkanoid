using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle
{
    public Vector2 A;
    public Vector2 B;
    public Vector2 C;
    public Vector2 D;

    public LineSegment[] GetLines()
    {
        return new LineSegment[]
        {
            new LineSegment(A, B),
            new LineSegment(A, D),
            new LineSegment(C, B),
            new LineSegment(C, D)
        };
    }
}
