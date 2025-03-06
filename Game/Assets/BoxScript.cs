using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float speed = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            myRigidBody.linearVelocity = Vector2.right * this.speed;
        if (Input.GetKey(KeyCode.A))
            myRigidBody.linearVelocity = Vector2.left * this.speed;
        if (Input.GetKeyDown(KeyCode.Space))
            myRigidBody.linearVelocity = Vector2.up * 5;
    }
}
