using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Platform : MonoBehaviour
{

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private Vector2 startPosition;

    private Vector3 prevPosition;

    [Inject]
    private CollisionManager collisionManager;
    public void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        prevPosition = transform.position;
        transform.position += movement * speed * Time.deltaTime;
    }

    public void MoveToStartPosition()
    {
        transform.position = startPosition;
    }

    void Update()
    {
        Move();
        if (collisionManager.CheckCollisions(transform.ToRectangle()))
        {
            transform.position = prevPosition;   
        }
    }
}
