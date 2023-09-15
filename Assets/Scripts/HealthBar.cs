using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage; // Reference to the Image component
    public Enemy currentEnemy; // Reference to the Enemy script
    public float maxHealth = 100; // Maximum health value

    private void Start()
    {
        maxHealth = currentEnemy.startHealth;
        // Ensure that the healthBarImage is assigned properly
        if (healthBarImage == null)
        {
            healthBarImage = GetComponent<Image>();
        }

        // Ensure that currentHealth is assigned properly in the Inspector
        if (currentEnemy == null)
        {
            Debug.LogError("currentHealth reference is not set.");
            return;
        }

        // Initialize the health bar color based on initial health
        UpdateHealthBarColor();
    }

    private void Update()
    {
        // Continuously monitor the enemy's health and update the health bar color
        UpdateHealthBarLevel();
        UpdateHealthBarColor();
    }

    private void UpdateHealthBarLevel()
    {
       healthBarImage.fillAmount = currentEnemy.health / currentEnemy.startHealth;
    }

    // Function to update the health bar's color based on remaining health
    private void UpdateHealthBarColor()
    {
        // Calculate the remaining health
        float remainingHealth = (float)currentEnemy.health / maxHealth;

        // Interpolate the color based on remaining health
        Color lerpedColor = Color.Lerp(Color.red, Color.green, remainingHealth);

        // Apply the color to the health bar
        healthBarImage.color = lerpedColor;
    }
}












