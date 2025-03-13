using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{

    public int maxHealth = 2;
    private int currentHealth;
    [SerializeField] private UpdateUIScript updateUIScript;
    [SerializeField] private Transform _deadZone;

    void Start()
    {
        currentHealth = maxHealth;
        updateUIScript.ResetStats(currentHealth);
    }

    void Update()
    {
        if (IsInDeadZone())
            TakeDamage(maxHealth);
        if (IsDead())
            Die();
    }

    void FixedUpdate()
    {
        updateUIScript.UpdateHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        updateUIScript.UpdateHealth(currentHealth);
    //    Debug.Log("Current Health: " + currentHealth);
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

    private void Restart()
    {
        currentHealth = maxHealth;
    }

    private bool IsInDeadZone()
    {
        return transform.position.y < _deadZone.position.y;
    }

    private bool IsDead()
    {
        return currentHealth <= 0;
    }
}
