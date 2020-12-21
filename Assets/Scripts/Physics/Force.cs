using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Force
{
    public static Vector2 SpecularReflection(Vector2 velocity, LineSegment line)
    {
        return Vector2.Reflect(velocity, line.GetNormalVector());
    }
}
