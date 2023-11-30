using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro; // Import the TMPro namespace

public class Enemy : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public string unitName;
    public int damage;
    public int block;
    public int strength;
    public string status;
    //public TMP_Text healthText; // Reference to the TextMeshPro Text component
    public bool TakeDamage(int dmg)
    {
        if(dmg > block)
        {
            currentHealth -= dmg;
        }

        block = 0;
        
        return currentHealth <= 0;
    }

    public void SetBlock(int val)
    {
        block = val;
    }

    public void setStats(int val)
    {
        currentHealth += val;
        maxHealth += val;
        damage += val;
    }
}
