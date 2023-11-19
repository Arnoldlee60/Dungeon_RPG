using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattleHUD : MonoBehaviour
{
    public Text enemyHP;
    public Text enemyBlock;

    public void setHUD(Enemy enemyUnit)
    {
        enemyHP.text =  enemyUnit.unitName + " hp: " + enemyUnit.currentHealth + "/" + enemyUnit.maxHealth;
        enemyBlock.text = "";
        if(enemyUnit.block > 0)
        {
            enemyBlock.text = "Block: " + enemyUnit.block + "\n";
        }
    }
    public void setHP(int hp)
    {
        enemyHP.text = "" + hp;
    }
}
