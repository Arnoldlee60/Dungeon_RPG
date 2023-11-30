using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleHUD : MonoBehaviour
{
    public Text playerHP;
    public Text playerEnergy;
    public Text playerStatus;
    public Text playerBlock;
    public Text playerRelic;
    
    void Awake()
    {
        //Debug.Log("ASDFEFD");
    }

    public void setHUD(Player playerUnit)
    {
        playerHP.text = playerUnit.unitName + " hp: " + playerUnit.currentHealth + "/" + playerUnit.maxHealth;
        playerEnergy.text = "Energy: " + playerUnit.energy;
        playerStatus.text = "Strength: " + playerUnit.strength;
        playerBlock.text = "Block: " + playerUnit.block;
        playerRelic.text = "Relic: " + playerUnit.relic;
    }
    public void setHP(int hp, Player playerUnit)
    {
        playerHP.text = playerUnit.unitName + " hp: " + hp + "/" + playerUnit.maxHealth;
    }

    public void setMaxHP(int hp, Player playerUnit)
    {
        playerUnit.maxHealth += hp;
        playerHP.text = playerUnit.unitName + " hp: " + playerUnit.currentHealth + "/" + playerUnit.maxHealth;
    }

    public void setHPFull(Player playerUnit)
    {
        playerUnit.currentHealth = playerUnit.maxHealth;
        playerHP.text = playerUnit.unitName + " hp: " + playerUnit.currentHealth + "/" + playerUnit.maxHealth;
    }

    public void setEnergy(int energy, Player playerUnit)
    {
        playerUnit.energy = energy;
        playerEnergy.text = "Energy: " + playerUnit.energy;
    }
    public void setBlock(int block, Player playerUnit)
    {
        playerUnit.block += block;
        playerBlock.text = "Block: " + playerUnit.block;
    }

    public void setStr(int str, Player playerUnit)
    {
        playerUnit.strength += str;
        playerStatus.text = "Strength: " + playerUnit.strength;
    }

    public void setMaxEnergy(int en, Player playerUnit)
    {
        playerUnit.energy += en;
        playerUnit.maxEnergy += en;
    }

    public void setBlessing(string blessing,Player playerUnit)
    {
        playerUnit.relic = blessing;
        playerRelic.text = "Relic: " + playerUnit.relic;
    }
}
