using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollider:MonoBehaviour
{
    public Rectangle GetRectangle()
    {
        return transform.ToRectangle();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
