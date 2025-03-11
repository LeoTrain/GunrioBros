using UnityEngine;

public class SpawnObjectScript : MonoBehaviour
{
    public GameObject player;
    public GameObject shroom_red;
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
        if (collision.gameObject.tag == "Player" && PlayerComesFromBottom())
        {
            SpawnAbove();
        }
    }

    void SpawnAbove()
    {
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + transform.localScale.y);
        Instantiate(shroom_red, spawnPosition, Quaternion.identity);
    }

    bool PlayerComesFromBottom()
    {
        float playerY = player.transform.position.y;
        float shroomY = transform.position.y;
        if (playerY < shroomY)
            return true;
        return false;
    }
}
