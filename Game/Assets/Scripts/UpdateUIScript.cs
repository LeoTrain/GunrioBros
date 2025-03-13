using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class UpdateUIScript : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(int health)
    {
        _healthText.text = "Health: " + health;
    }

    public void ResetStats(int health)
    {   
        _healthText.text = "Health: " + health;
    }
}
