using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 30f;
    public Rigidbody2D rb;
    private float dx;
    private bool isBouncing = false;

    private float moveX;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dx = Input.acceleration.x * moveSpeed;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = dx;
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 contactNormal = collision.contacts[0].normal;
        if (collision.gameObject.tag == "Platform"  && Vector3.Dot(contactNormal, Vector3.up) > 0.7f && !isBouncing)
        {
            isBouncing = true;
            Debug.Log("hit ground");
            GetComponent<Animator>().SetBool("bouncing", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isBouncing = false;
            Debug.Log("left ground");
            GetComponent<Animator>().SetBool("bouncing", false);
        }
    }
}
