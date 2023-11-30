using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Gym_Event : MonoBehaviour
{
    public GameObject playerPrefab;

    public Transform playerBattleStation;

    Player playerUnit;

    public Text dialogueText;
    public Text playerHP;
    public Text playerEnergy;
    public Text playerStatus;

    // Reference to your buttons
    public Button liftButton;
    public Button cardioButton;
    public Button yogaButton;
    public Button nextScene;

    public PlayerBattleHUD PlayerHUD;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GymEvent());

        if(playerUnit.strength != 0)
        {
            playerStatus.text = "Strength: " + playerUnit.strength +"\n";
        }
    }

    IEnumerator GymEvent()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Player>();

        playerUnit.setStats();

        PlayerHUD.setHUD(playerUnit);

        yield return new WaitForSeconds(2f);
    }

    // Define the button click functions
    public void OnLiftButtonClick()
    {
        // Handle the Lift button click here
        // playerUnit.strength += 2;
        //playerUnit.gainStr();

        if(playerUnit.energy > 0)
        {
            StartCoroutine(PlayerStrength());
            PlayerHUD.setEnergy(playerUnit.energy - 1, playerUnit);
        }
        else{
            dialogueText.text = "Not enough energy!";
        }
    }

    public void OnCardioButtonClick()
    {
        // Handle the Cardio button click here

        if(playerUnit.energy > 0)
        {
            StartCoroutine(PlayerMaxEnergyGain());
            PlayerHUD.setEnergy(playerUnit.energy - 2, playerUnit);
        }
        else{
            dialogueText.text = "Not enough energy!";
        }

    }

    public void OnYogaButtonClick()
    {
        // Handle the Yoga button click here
        if(playerUnit.energy > 0)
        {
            StartCoroutine(PlayerMaxHealth());
            PlayerHUD.setEnergy(playerUnit.energy - 1, playerUnit);
        }
        else{
            dialogueText.text = "Not enough energy!";
        }
    }

    IEnumerator PlayerStrength()
    {
        PlayerHUD.setStr(5, playerUnit);
        dialogueText.text = "Player gains Strength: " + playerUnit.strength + "!";
        playerUnit.gainStr();

        yield return new WaitForSeconds(2f);
    }

    IEnumerator PlayerMaxEnergyGain()
    {
        PlayerHUD.setMaxEnergy(1, playerUnit);
        dialogueText.text = "Player Max Energy is now: " + playerUnit.maxEnergy + "!";
        playerUnit.gainMaxEnergy();

        yield return new WaitForSeconds(2f);
    }

    IEnumerator PlayerMaxHealth()
    {
        PlayerHUD.setMaxHP(5, playerUnit);
        dialogueText.text = "Player gains max hp: " + playerUnit.maxHealth + " total hp!";
        playerUnit.gainMaxHp();

        yield return new WaitForSeconds(2f);
    }

    public void nextSceneEnd()
    {
        PlayerStats.roomCounter++;
        SceneManager.LoadScene("Battle");
    }
}
