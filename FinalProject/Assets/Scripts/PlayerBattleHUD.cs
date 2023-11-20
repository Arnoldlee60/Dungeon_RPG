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
    
    void Awake()
    {
        //Debug.Log("ASDFEFD");
    }

    public void setHUD(Player playerUnit)
    {
        playerHP.text = playerUnit.unitName + " hp: " + playerUnit.currentHealth + "/" + playerUnit.maxHealth;
        playerEnergy.text = "Energy: " + playerUnit.energy;

        //Make if statements to add onto status effects 
        playerStatus.text = "";
        if(playerUnit.strength != 0)
        {
            playerStatus.text += "STR: " + playerUnit.strength +"\n";
        }
    }
    public void setHP(int hp, Player playerUnit)
    {
        playerHP.text = playerUnit.unitName + " hp: " + hp + "/" + playerUnit.maxHealth;
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
}
