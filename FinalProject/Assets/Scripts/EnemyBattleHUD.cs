using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattleHUD : MonoBehaviour
{
    public Text enemyHP;
    public Text enemyBlock;
    public Text enemyStrength;
    public Text enemyStatus;

    public void setHUD(Enemy enemyUnit)
    {
        enemyHP.text =  enemyUnit.unitName + " hp: " + enemyUnit.currentHealth + "/" + enemyUnit.maxHealth;
        enemyBlock.text = "";
        enemyStrength.text = "";
        enemyStatus.text = "";

        if(enemyUnit.block > 0)
        {
            enemyBlock.text = "Block: " + enemyUnit.block + "\n";
        }

        if(enemyUnit.strength > 0)
        {
            enemyStrength.text = "Strength: " + enemyUnit.strength + "\n";
        }

        if(enemyUnit.status != "")
        {
            enemyBlock.text = "Status WIP";
        }
    }
    public void setHP(int hp, Enemy enemyUnit)
    {
        enemyHP.text = enemyUnit.unitName + " hp: " + enemyUnit.currentHealth + "/" + enemyUnit.maxHealth;
    }
    public void setStr(int str, Enemy enemyUnit)
    {
        enemyUnit.strength += str;

        enemyStrength.text = "Strength: " + enemyUnit.strength;
    }
    public void setStatus(string status, Enemy enemyUnit)
    {
        enemyUnit.status = status;
        enemyStatus.text = enemyUnit.status;
    }
    public void setBlock(int val, Enemy enemyUnit)
    {
        enemyUnit.block = val;

        enemyBlock.text = "Block: " + enemyUnit.block;
    }
}
