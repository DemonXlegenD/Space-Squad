using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthSlider;

    // Appeler cette fonction pour mettre à jour la barre de vie
    public void SetHealth(float health, float maxHealth)
    {
        healthSlider.value = health / maxHealth;
    }
}
