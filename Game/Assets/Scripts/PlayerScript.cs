using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool isFacingRight = false;
    public Rigidbody2D myRigidBody;
    public float speed = 4f;
    public float acceleration = 15f;
    public float deceleration = 10f;
    public float jumpHeight = 7;
    public int jumpCount = 0;
    public Animator animator;
    public GameObject current_weapon;
    [SerializeField] private Transform _grabPoint;
    private float moveInput = 0f;
    [SerializeField] private CinemachineConfiner2D _cinemachineConfiner;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.animator = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        this.moveInput = 0f;
        if (Input.GetKey(KeyCode.D)) { this.moveInput = 1f; isFacingRight = true; Turn(); };
        if (Input.GetKey(KeyCode.A)) { this.moveInput = -1f; isFacingRight = false; Turn(); };
        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount == 0) this.Jump();
        if ((Input.GetKeyUp(KeyCode.A) && !isFacingRight ) || (Input.GetKeyUp(KeyCode.D) && isFacingRight)) SetAnimatorBool("Idle");
    }

    void FixedUpdate()
    {
        Move();
    }

    void Turn()
    {
        transform.eulerAngles = isFacingRight ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0); 
        if (_grabPoint.transform.childCount > 0)
        {
            Transform gun = _grabPoint.transform.GetChild(0);
            GunScript gunScript = gun.GetComponent<GunScript>();
            if (gunScript != null)
                gunScript.FlipWeapon(isFacingRight);
            else
                Debug.LogWarning("GunScript not found on weapon!");
        }
    }

    void Move()
    { 
        if (moveInput != 0 && jumpCount == 0)
            SetAnimatorBool("Run");

        float targetVelocity = this.moveInput * this.speed;
        float velocityDifference = targetVelocity - this.myRigidBody.linearVelocity.x;
        float force = (this.moveInput != 0) ? this.acceleration * velocityDifference : -this.deceleration * this.myRigidBody.linearVelocity.x;
        this.myRigidBody.AddForce(Vector2.right * force, ForceMode2D.Force);
    }

    void Jump()
    {
        SetAnimatorBool("Jump");
        myRigidBody.linearVelocity = new Vector2(this.myRigidBody.linearVelocity.x, this.jumpHeight);
        jumpCount = 1;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Block")
        {
            this.jumpCount = 0;
            SetAnimatorBool("Idle");
        }
    }

    public void OnEnterPipe(Vector3 _teleportPoint)
    {
        // _cinemachineConfiner.enabled = false;
        this.transform.position = _teleportPoint;
    }

    public void SetAnimatorBool(string name)
    {
        switch (name)
        {
            case "Idle":
                animator.SetBool("isIdle", true);
                animator.SetBool("isRunning", false);
                animator.SetBool("isJumping", false);
                break;
            case "Run":
                animator.SetBool("isIdle", false);
                animator.SetBool("isRunning", true);
                animator.SetBool("isJumping", false);
                break;
            case "Jump":
                animator.SetBool("isIdle", false);
                animator.SetBool("isRunning", false);
                animator.SetBool("isJumping", true);
                break;
            case "Star":
                animator.SetBool("isStar", true);
                break;
        }
    }


}
