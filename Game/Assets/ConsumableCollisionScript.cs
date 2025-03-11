using UnityEngine;

public class ConsumableCollisionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScalePlayer()
    {
      // To modify with the actual growing logic
      this.transform.localScale = new Vector3(8, 8, 1);
    }
}
