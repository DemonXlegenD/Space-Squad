using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    
    public float maxHealth = 100f;
    public float currentHealth;
    public HealthBarController healthBarController;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBarController.SetHealth(currentHealth, maxHealth);
    }

    // Fonction pour infliger des dégâts
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBarController.SetHealth(currentHealth, maxHealth);
    }

    public bool IsDead()
    {
        return currentHealth == 0;
    }
}
