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
        return rect;
    }
}
