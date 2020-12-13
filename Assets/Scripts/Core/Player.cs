using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        Rect rect = new Rect(transform.position, transform.localScale);
        Debug.Log(rect);
        Debug.Log(transform.position.x - transform.localScale.x / 2);
        Debug.Log(transform.position.x + transform.localScale.x / 2);
        Debug.Log(transform.position.y - transform.localScale.y / 2);
        Debug.Log(transform.position.y + transform.localScale.y / 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
