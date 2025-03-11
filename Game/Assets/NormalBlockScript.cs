using UnityEngine;

public class NormalBlockScript : MonoBehaviour
{
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
            this.DestroyObject();
        }
    }

    private void DestroyObject()
    {
        // Too change with the sprite change
        Destroy(this.gameObject);
    }
}
