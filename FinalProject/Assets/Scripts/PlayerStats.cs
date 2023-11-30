using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int level = 2;
    public static int currentHealth = 10;
    public static int maxHealth = 10;
    public static string unitName = "Night Knight";
    public static int damage = 1;
    public static int strength = 0;
    public static int energy = 3;
    public static int maxEnergy = 3;
    public static int block = 0;
    public static string relic = "None";

    public static int roomCounter = 0;
    public static int monsterEncounters = 0;

    public static void Reset()
    {
        level = 2;
        currentHealth = 10;
        maxHealth = 10;
        unitName = "Night Knight";
        damage = 1;
        strength = 0;
        energy = 3;
        maxEnergy = 3;
        block = 0;
        relic = "None";
    }
}
