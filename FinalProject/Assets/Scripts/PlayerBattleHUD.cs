using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleHUD : MonoBehaviour
{
    public Text playerHP;
    public Text playerEnergy;
    public Text playerStatus;
    
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
    public void setHP(int hp)
    {
        playerHP.text = "" + hp;
    }
}
