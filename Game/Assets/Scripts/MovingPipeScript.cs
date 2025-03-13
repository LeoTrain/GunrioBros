using UnityEngine;

public class MovingPipeScript : MonoBehaviour
{
    [SerializeField] private Transform _teleportPoint;
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
        if (IsPlayer(collision.gameObject) && IsPlayerOnTop(collision.gameObject) && IsPlayerPressingDown(collision.gameObject))
        {
            TeleportPlayer(collision.gameObject);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        player.transform.position = _teleportPoint.position;
    }

    private bool IsPlayerPressingDown(GameObject player)
    {
        return Input.GetKey(KeyCode.S);
    }

    private bool IsPlayerOnTop(GameObject player)
    {
        return player.transform.position.y > transform.position.y;
    }

    private bool IsPlayer(GameObject other)
    {
        return other.CompareTag("Player");
    }
}
