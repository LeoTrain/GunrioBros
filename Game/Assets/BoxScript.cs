using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float speed = 4;
    public float jumpHeight = 7;
    public int jumpCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && this.jumpCount == 0)
            myRigidBody.linearVelocity = Vector2.right * this.speed;
        if (Input.GetKey(KeyCode.A) && this.jumpCount == 0)
            myRigidBody.linearVelocity = Vector2.left * this.speed;
        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount == 0)
            this.Jump();
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
