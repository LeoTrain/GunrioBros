using System;
using UnityEngine;

public class ConsumableCollisionScript : MonoBehaviour
{
    private bool isBigger = false;
    private DateTime lastGrowTime;
    private float growDuration = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (isBigger && DateTime.Now.Subtract(lastGrowTime).TotalSeconds > growDuration)
      {
        this.transform.localScale = new Vector3(2, 2, 1);
        isBigger = false;
      }
        
    }

    public void ScalePlayer()
    {
      // To modify with the actual growing logic
      this.transform.localScale = new Vector3(4, 4, 1);
      isBigger = true;
      lastGrowTime = DateTime.Now;
    }
}
