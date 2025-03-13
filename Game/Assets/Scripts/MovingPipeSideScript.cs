using UnityEngine;

public class MovingPipeSideScript : MonoBehaviour
{
    [SerializeField] private Transform _teleportPoint;
    [SerializeField] private bool _isLeftSide;
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
        player.GetComponent<PlayerScript>().OnEnterPipe(_teleportPoint.position);
    }

    private bool IsPlayerPressingDown(GameObject player)
    {
        if (_isLeftSide)
            return Input.GetKey(KeyCode.D);
        else
            return Input.GetKey(KeyCode.A);
    }

    private bool IsPlayerOnTop(GameObject player)
    {
        if (_isLeftSide)
            return player.transform.position.x < transform.position.x;
        else
            return player.transform.position.x > transform.position.x;
    }

    private bool IsPlayer(GameObject other)
    {
        return other.CompareTag("Player");
    }
}
