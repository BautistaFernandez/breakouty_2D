using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;

    private float inputValue;

    public float moveSpeed = 25;

    private Vector2 direction;

    Vector2 startPosition; //Without private or public, still set at private.

    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        inputValue = Input.GetAxisRaw("Horizontal");

        if (inputValue == 1)
        {
            direction = Vector2.right;
        }
        else if (inputValue == -1)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.zero;
        }

        rigidBody2D.AddForce(direction * moveSpeed * Time.deltaTime * 100);
    }

    public void ResetBar()
    {
        transform.position = startPosition;

        rigidBody2D.velocity = Vector2.zero;
    }
}
