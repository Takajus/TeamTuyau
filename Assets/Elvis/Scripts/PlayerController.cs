using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private float force = 5;

    private Transform tr;
    private Rigidbody2D rb;
    
    private KeyCode jump = KeyCode.Space;
    private KeyCode forward = KeyCode.D;
    private KeyCode backward = KeyCode.Q;
    
    private bool canJump = true;
    
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(jump))
        {
            if (canJump)
            {
                canJump = false;
                Jump();
            }
        }

        if (Input.GetKey(forward))
        {
            Move(Vector2.right);
        }
        else if (Input.GetKey(backward))
        {
            Move(Vector2.left);
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * force);
    }

    private void Move(Vector3 dir)
    {
        tr.position += dir * (speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            canJump = false;
        }
    }
}
