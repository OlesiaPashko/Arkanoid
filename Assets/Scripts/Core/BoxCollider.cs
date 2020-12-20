using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollider:MonoBehaviour
{
    public Rectangle GetRectangle()
    {
        return transform.ToRectangle();
    }
}
