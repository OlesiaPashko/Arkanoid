using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtention
{
    public static Rectangle ToRectangle(this Transform transform)
    {
        Rectangle rect = new Rectangle();
        rect.A = new Vector2(transform.position.x - transform.localScale.x / 2, transform.position.y - transform.localScale.y / 2);
        rect.B = new Vector2(transform.position.x - transform.localScale.x / 2, transform.position.y + transform.localScale.y / 2);
        rect.C = new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y + transform.localScale.y / 2);
        rect.D = new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y - transform.localScale.y / 2);
        return RotateRectangle(rect, Mathf.Deg2Rad * transform.rotation.eulerAngles.z, transform.position);
    }

    static private Rectangle RotateRectangle(Rectangle rect, float angle, Vector2 position)
    {
        Rectangle rotatedRect = new Rectangle();
        rotatedRect.A = RotateRelativeTo(rect.A, position, angle);
        rotatedRect.B = RotateRelativeTo(rect.B, position, angle);
        rotatedRect.C = RotateRelativeTo(rect.C, position, angle);
        rotatedRect.D = RotateRelativeTo(rect.D, position, angle);
        return rotatedRect;

    }

    static private Vector2 RotateRelativeTo(Vector2 point, Vector2 relativePoint, float angle)
    {
        Vector2 diagonal = point - relativePoint;
        diagonal = RotateVector2(diagonal, angle);
        return diagonal + relativePoint;
    }

    static Vector2 RotateVector2(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
}
