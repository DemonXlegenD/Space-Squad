using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public float lowHealth = 50f;
    public float maxHealth = 100f;
    public float currentHealth;
    public HealthBarController healthBarController;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBarController.SetHealth(currentHealth, maxHealth);
    }

    public void TakeDamage(float _damage)
    {
        currentHealth -= _damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBarController.SetHealth(currentHealth, maxHealth);
    }

    public void Healing(float _health)
    {
        currentHealth += _health;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBarController.SetHealth(currentHealth, maxHealth);
    }

    public bool IsMaxHealth()
    {
        return currentHealth == maxHealth;
    }

    public bool IsMidHealth()
    {
        return currentHealth == maxHealth / 2f;
    }

    public bool IsLowHealth()
    {
        return currentHealth <= lowHealth;
    }

    public bool IsDead()
    {
        return currentHealth == 0;
    }
}
