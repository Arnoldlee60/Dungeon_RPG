using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro; // Import the TMPro namespace

public class Player : MonoBehaviour
{
        public int level;
        public int currentHealth;
        public int maxHealth;
        public string unitName;
        public int damage;
        public int strength;
        public int energy;
        
        public bool TakeDamage(int dmg)
        {
                currentHealth -= dmg;
                return currentHealth <= 0;
        }
}
