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
        public int maxEnergy;
        public int block;
        
        public bool TakeDamage(Enemy enemyUnit)
        {
                int dmg = enemyUnit.damage + enemyUnit.strength - block;
                if(dmg < 0)
                {
                        dmg = 0;
                }
                currentHealth -= dmg;
                return currentHealth <= 0;
        }

        public void setStats()
        {
                level = PlayerStats.level;
                currentHealth = PlayerStats.currentHealth;
                maxHealth = PlayerStats.maxHealth;
                unitName = PlayerStats.unitName;
                damage = PlayerStats.damage;
                strength = PlayerStats.strength;
                energy = PlayerStats.energy;
                maxEnergy = PlayerStats.maxEnergy;
                block = PlayerStats.block;
        }

        public void updateStats(int level, int currentHealth, int maxHealth, int damage, int strength, int energy, int maxEnergy)
        {
                PlayerStats.level = level + 1;
                PlayerStats.currentHealth = currentHealth;
                PlayerStats.maxHealth = maxHealth;
                PlayerStats.damage = damage;
                PlayerStats.strength = strength;
                PlayerStats.energy = energy;
                PlayerStats.maxEnergy = maxEnergy;
                PlayerStats.block = 0;
        }
}
