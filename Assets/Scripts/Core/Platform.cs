using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private static Platform _instance;

    public static Platform Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private Vector2 startPosition;

    private Vector3 prevPosition;
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
        if (CollisionManager.CheckCollisions(transform.ToRectangle()))
        {
            transform.position = prevPosition;   
        }
    }
}
