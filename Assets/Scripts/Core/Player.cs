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
        
    }
    void Update()
    {
        Move();
        //Rectangle rect = transform.ToRectangle();
        //Debug.LogError($"A = {rect.A}, B = {rect.B}, C = {rect.C}, D = {rect.D} ");
    }
}
