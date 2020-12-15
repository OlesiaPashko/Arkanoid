using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;

    public void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        transform.position += movement * speed * Time.deltaTime;
    }


    void Start()
    {
        Rect rect = new Rect(transform.position, transform.localScale);
        Debug.Log(rect);
        Debug.Log(transform.position.x - transform.localScale.x / 2);
        Debug.Log(transform.position.x + transform.localScale.x / 2);
        Debug.Log(transform.position.y - transform.localScale.y / 2);
        Debug.Log(transform.position.y + transform.localScale.y / 2);
    }
    void Update()
    {
        Move();
    }
}
