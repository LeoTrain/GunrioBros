using UnityEngine;

public class SpawnObjectScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] objects;
    [SerializeField] Sprite[] sprites;
    [SerializeField] Sprite currentSprite;
    private bool hasBeenHit = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && PlayerComesFromBottom() && !hasBeenHit)
        {
            currentSprite = sprites[1];
            gameObject.GetComponent<SpriteRenderer>().sprite = currentSprite;
            SpawnAbove();
            hasBeenHit = true;
        }
    }

    void SpawnAbove()
    {
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + transform.localScale.y);
        int randomIndex = Random.Range(0, objects.Length);
        Instantiate(objects[randomIndex], spawnPosition, Quaternion.identity);
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
