using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float speed = 4f;
    public float acceleration = 15f;
    public float deceleration = 10f;
    public float jumpHeight = 7;
    public int jumpCount = 0;

    private float moveInput = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.moveInput = 0f;
        if (Input.GetKey(KeyCode.D)) this.moveInput = 1f;
        if (Input.GetKey(KeyCode.A)) this.moveInput = -1f;
        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount == 0) this.Jump();
    }

    void FixedUpdate()
    {
        this.Move();
    }

    void Move()
    { 
        float targetVelocity = this.moveInput * this.speed;
        float velocityDifference = targetVelocity - this.myRigidBody.linearVelocity.x;
        float force = (this.moveInput != 0) ? this.acceleration * velocityDifference : -this.deceleration * this.myRigidBody.linearVelocity.x;
        this.myRigidBody.AddForce(Vector2.right * force, ForceMode2D.Force);
    }

    void Jump()
    {
        myRigidBody.linearVelocity = new Vector2(this.myRigidBody.linearVelocity.x, this.jumpHeight);
        this.jumpCount = 1;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            this.jumpCount = 0;
        }
    }
}
