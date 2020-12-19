using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Force
{
    public static Vector2 SpecularReflection(Vector2 velocity, Line line)
    {
        /*if(CollisionDetector.IsCollision(line, velocity))
        {
            Vector2 collisionPoint = CollisionDetector.GetIntersectPoint(line, velocity);
            Vector2 newVelocity = 2 * line.GetNormalVector().
        }*/
        return Vector2.Reflect(velocity, line.GetNormalVector());
    }
}
