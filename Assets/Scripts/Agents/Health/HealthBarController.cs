using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthSlider;

    public void SetHealth(float health, float maxHealth)
    {
        healthSlider.value = health / maxHealth;
    }
}
