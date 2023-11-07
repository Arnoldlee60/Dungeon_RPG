using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Battle_State { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class Battle_System : MonoBehaviour
{

    public Battle_State state;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Player playerUnit;
    Enemy enemyUnit;

    public Text dialogueText;
    public Text playerHP;
    public Text playerEnergy;
    public Text playerStatus;

    public Text enemyHP;
    public Text enemyBlock;

    // Start is called before the first frame update
    void Start()
    {
        state = Battle_State.START;
        SetupBattle();
    }

    void Update()
    {
        //dialogueText.text = "The enemy " + enemyUnit.maxHealth;
        playerHP.text = playerUnit.unitName + " hp: " + playerUnit.currentHealth + "/" + playerUnit.maxHealth;
        playerEnergy.text = "Energy: " + playerUnit.energy;
        //Make if statements to add onto status effects 
        playerStatus.text = "";
        if(playerUnit.strength != 0)
        {
            playerStatus.text += "STR: " + playerUnit.strength +"\n";
        }

        enemyHP.text =  enemyUnit.unitName + " hp: " + enemyUnit.currentHealth + "/" + enemyUnit.maxHealth;
        enemyBlock.text = "";
        if(enemyUnit.block > 0)
        {
            enemyBlock.text = "Block: " + enemyUnit.block + "\n";
        }
    }
    void SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Player>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Enemy>();
    }
}
