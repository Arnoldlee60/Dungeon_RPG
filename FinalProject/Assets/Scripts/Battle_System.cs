using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    int turnCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        state = Battle_State.START;
        StartCoroutine(SetupBattle());

        dialogueText.text = "A wild " + enemyUnit.unitName + " appears!";
        //Debug.Log("Player Level: " + PlayerStats.level);
    }

    void Update()
    {

    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Player>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Enemy>();

        playerUnit.setStats();

        PlayerHUD.setHUD(playerUnit);
        EnemyHUD.setHUD(enemyUnit);

        yield return new WaitForSeconds(2f);
        state = Battle_State.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        EnemyHUD.setHP(enemyUnit.currentHealth, enemyUnit);
        PlayerHUD.setEnergy(playerUnit.energy - 1, playerUnit);
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
    }

    IEnumerator PlayerBlock()
    {
        PlayerHUD.setBlock(5, playerUnit);
        PlayerHUD.setEnergy(playerUnit.energy - 1, playerUnit);
        dialogueText.text = "Player blocks for: " + 5 +"!";

        yield return new WaitForSeconds(2f);
    }

    IEnumerator SlimeTurn()
    {
        bool isDead = false; //playerUnit.TakeDamage(enemyUnit.damage + turnCounter);
        // PlayerHUD.setHP(playerUnit.currentHealth, playerUnit);

        // Debug.Log(turnCounter);
        if(turnCounter == 1)
        {
            EnemyHUD.setStatus(enemyUnit.unitName + " will now gain strength every turn!", enemyUnit);
        }
        else
        {
            dialogueText.text = enemyUnit.unitName + " gains 5 Strength and attacks!";
            EnemyHUD.setStr(2, enemyUnit);
            isDead = playerUnit.TakeDamage(enemyUnit);
        }

        PlayerHUD.setHP(playerUnit.currentHealth, playerUnit);

        yield return new WaitForSeconds(2f);

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
        turnCounter++;
        PlayerHUD.setEnergy(playerUnit.maxEnergy, playerUnit);
        PlayerHUD.setBlock(playerUnit.block * -1, playerUnit); //block goes to zero starting turn
    }
    

    void EndBattle()
    {
        playerUnit.updateStats(playerUnit.level, playerUnit.currentHealth, playerUnit.maxHealth, playerUnit.damage, playerUnit.strength, playerUnit.energy, playerUnit.maxEnergy);

        if(state == Battle_State.WON)
        {
            dialogueText.text = "You win the battle";

            //yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Event");
        }
        else if(state == Battle_State.LOST)
        {
            dialogueText.text = "You lost";

            //yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Main");
        }
    }

    public void OnAttackButton()
    {
        if(state != Battle_State.PLAYERTURN)
        {
            return;
        }
        if(playerUnit.energy > 0)
        {
            StartCoroutine(PlayerAttack());
        }
        else
        {
            return;
        }
    }

    public void OnBlockButton()
    {
        if(state != Battle_State.PLAYERTURN)
        {
            return;
        }
        if(playerUnit.energy > 0)
        {
            StartCoroutine(PlayerBlock());
        }
        else
        {
            return;
        }
    }

    public void End_Turn()
    {
            //change turn
            state = Battle_State.ENEMYTURN;
            if(enemyUnit.unitName == "Slime")
            {
                StartCoroutine(SlimeTurn());
            }
            else if(enemyUnit.unitName == "Other Enemy")
            {
                
            }
            else
            {
                Debug.Log("Enemy AI messed up!");
            }

    }
}
