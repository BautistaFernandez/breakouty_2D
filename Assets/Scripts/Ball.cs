using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;

    public float speed = 300;

    private Vector2 velocity;

    Vector2 startPosition;

    public AudioSource audioSource;

    public AudioClip barSound, destroySound, wallSound, deadZoneSound;

    // Update is called once per frame
    void Start()
    {
        startPosition = transform.position;

        ResetBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            audioSource.clip = deadZoneSound;
            audioSource.Play();
            FindObjectOfType<GameManager>().LoseHealth();
        }

        if (collision.gameObject.GetComponent<Bar>())
        {
            audioSource.clip = barSound;
            audioSource.Play();
        }

        if (collision.gameObject.GetComponent<Brick>())
        {
            audioSource.clip = destroySound;
            audioSource.Play();
        }

        if (collision.transform.CompareTag("Wall"))
        {
            audioSource.clip = wallSound;
            audioSource.Play();
        }
    }

    public void ResetBall()
    {
        transform.position = startPosition;

        rigidBody2D.velocity = Vector2.zero;

        velocity.x = Random.Range(-1f, 1f);

        velocity.y = 1;

        rigidBody2D.AddForce(velocity * speed);
    }
}
