using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TMPro namespace

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public TMP_Text healthText; // Reference to the TextMeshPro Text component

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText(); // Call this to update the UI when the game starts
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the health value has changed
        if (Input.GetKeyDown(KeyCode.Space)) // For example, change health when the space key is pressed
        {
            ModifyHealth(-1); // Reduce health by 1
        }
    }

    // Update the TextMeshPro Text to display current health
    void UpdateHealthText()
    {
        healthText.text = "Health: " + currentHealth + " / " + maxHealth;
    }

    // You can call this function whenever the health changes
    void ModifyHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go below 0 or above maxHealth
        UpdateHealthText(); // Update the TextMeshPro Text with the new health value
    }
}
