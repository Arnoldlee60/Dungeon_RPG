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

    public PlayerBattleHUD PlayerHUD;
    public EnemyBattleHUD EnemyHUD;

    public Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        state = Battle_State.START;
        StartCoroutine(SetupBattle());

        dialogueText.text = "A wild " + enemyUnit.unitName + " appears!";
    }

    void Update()
    {

    }
    
    // void HUD()
    // {
    //     //dialogueText.text = "The enemy " + enemyUnit.maxHealth;
    //     playerHP.text = playerUnit.unitName + " hp: " + playerUnit.currentHealth + "/" + playerUnit.maxHealth;
    //     playerEnergy.text = "Energy: " + playerUnit.energy;
    //     //Make if statements to add onto status effects 
    //     playerStatus.text = "";
    //     if(playerUnit.strength != 0)
    //     {
    //         playerStatus.text += "STR: " + playerUnit.strength +"\n";
    //     }

    //     enemyHP.text =  enemyUnit.unitName + " hp: " + enemyUnit.currentHealth + "/" + enemyUnit.maxHealth;
    //     enemyBlock.text = "";
    //     if(enemyUnit.block > 0)
    //     {
    //         enemyBlock.text = "Block: " + enemyUnit.block + "\n";
    //     }
    // }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Player>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Enemy>();

        PlayerHUD.setHUD(playerUnit);
        EnemyHUD.setHUD(enemyUnit);

        yield return new WaitForSeconds(2f);
        state = Battle_State.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        EnemyHUD.setHP(enemyUnit.currentHealth);
        dialogueText.text = "Player attacks for: " + playerUnit.damage + " Damage!";

        yield return new WaitForSeconds(2f);
        //check if enemy dead
        //Change state based on conditions
        if(isDead)
        {
            //next scene
            state = Battle_State.WON;
            EndBattle();
        }
        else
        {
            //change turn
            state = Battle_State.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        PlayerHUD.setHP(playerUnit.currentHealth);

        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            //next scene
            state = Battle_State.LOST;
            EndBattle();
        }
        else
        {
            //change turn
            state = Battle_State.PLAYERTURN;
            PlayerTurn();
        }

        
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action: ";
    }

    void EndBattle()
    {
        if(state == Battle_State.WON)
        {
            dialogueText.text = "You win the battle";
        }
        else if(state == Battle_State.LOST)
        {
            dialogueText.text = "You lost";
        }
    }

    public void OnAttackButton()
    {
        if(state != Battle_State.PLAYERTURN)
        {
            return;
        }
        
        StartCoroutine(PlayerAttack());
    }
}
