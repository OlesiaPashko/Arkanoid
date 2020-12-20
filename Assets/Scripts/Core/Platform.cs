using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    private Vector3 prevPosition;
    public void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        prevPosition = transform.position;
        transform.position += movement * speed * Time.deltaTime;
    }
    void Update()
    {
        Move();
        if (CollisionManager.CheckCollisions(transform.ToRectangle()))
        {
            
            transform.position = prevPosition;   
        }
        //Rectangle rect = transform.ToRectangle();
        //Debug.LogError($"A = {rect.A}, B = {rect.B}, C = {rect.C}, D = {rect.D} ");
    }
}
