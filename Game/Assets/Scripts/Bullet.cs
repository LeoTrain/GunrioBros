using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    private Rigidbody2D rb;
    public int damage = 1;
    [SerializeField] private GameObject player;
    private UnityEngine.Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        SetDirection();
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = speed * direction;
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<GoombaScript>().TakeDamage(this.damage);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            return ;
        }
        Destroy(gameObject);
    }

    private void SetDirection()
    {
        direction = player.GetComponent<PlayerScript>().isFacingRight ? transform.right : transform.right * -1;
    }
}
