using UnityEngine;

public class RedShroomScript : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "Player")
      {
        collision.gameObject.GetComponent<ConsumableCollisionScript>().ScalePlayer();
        Destroy(this.gameObject);
      }
    }

    void FixedUpdate()
    {
      Vector2 direction = GetDirection();
      transform.Translate(direction * speed * Time.deltaTime);
    }

    Vector2 GetDirection()
    {
      GameObject player = GameObject.Find("Player");
      Vector2 direction = Vector2.left;
      if (player.transform.position.x < transform.position.x)
      {
        direction = Vector2.right;
      }
      return direction;
    }

}
