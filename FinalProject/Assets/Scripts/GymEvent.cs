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

    // Start is called before the first frame update
    void Start()
    {
        GymEvent();
    }

    void Update()
    {
        dialogueText.text = "You arrive at the Gym. What will you do? Lift(Strength) or Cardio(Max HP +10)";
        playerHP.text = playerUnit.unitName + " hp: " + playerUnit.currentHealth + "/" + playerUnit.maxHealth;
        playerEnergy.text = "Energy: " + playerUnit.energy;
        //Make if statements to add onto status effects 
        playerStatus.text = "";
        if(playerUnit.strength != 0)
        {
            playerStatus.text += "STR: " + playerUnit.strength +"\n";
        }
    }
    void GymEvent()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Player>();
    }

    // Define the button click functions
    public void OnLiftButtonClick()
    {
        // Handle the Lift button click here
        // playerUnit.strength += 2;
        playerUnit.strength = 1;
    }

    public void OnCardioButtonClick()
    {
        // Handle the Cardio button click here
        SceneManager.LoadScene("Battle");

    }

    void OnYogaButtonClick()
    {
        // Handle the Yoga button click here
    }
}
