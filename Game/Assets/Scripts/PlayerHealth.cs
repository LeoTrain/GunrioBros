using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{

    public int maxHealth = 2;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
      //  Debug.Log("Current Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void IncreaseHealth(int amount)
    {
        maxHealth += amount; // Adds extra maximum health
        currentHealth = maxHealth; // Restores health to full
    }



    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth); // Here we make sure that we can't overheal.
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
