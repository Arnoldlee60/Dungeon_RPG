using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Healing_Event : MonoBehaviour
{
    public GameObject playerPrefab;

    public Transform playerBattleStation;

    Player playerUnit;

    public Text dialogueText;
    public Text playerHP;
    public Text playerEnergy;
    public Text playerStatus;
    public Text playerRelic;

    // Reference to your buttons
    public Button Heal;
    public Button Blessing;
    public Button nextScene;

    public PlayerBattleHUD PlayerHUD;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HealingEvent());

        if(playerUnit.strength != 0)
        {
            playerStatus.text += "Strength: " + playerUnit.strength +"\n";
        }
    }

    public void OnHealButton()
    {
        if(playerUnit.energy > 0)
        {
            StartCoroutine(PlayerHealToFull());
            PlayerHUD.setEnergy(playerUnit.energy - 1, playerUnit);
            PlayerHUD.setHUD(playerUnit);
            dialogueText.text = "You healed to full HP!";
        }
        else{
            dialogueText.text = "Not enough energy!";
        }
    }

    public void OnBlessingButton()
    {
        if(playerUnit.energy > 0)
        {
            StartCoroutine(PlayerBlessing());
            PlayerHUD.setEnergy(playerUnit.energy - 1, playerUnit);
            PlayerHUD.setHUD(playerUnit);
            dialogueText.text = "You gained " + playerUnit.relic + " relic!";
        }
        else{
            dialogueText.text = "Not enough energy!";
        }
    }

    IEnumerator HealingEvent()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Player>();

        playerUnit.setStats();

        PlayerHUD.setHUD(playerUnit);
        PlayerHUD.setEnergy(1, playerUnit);

        yield return new WaitForSeconds(2f);
    }

    IEnumerator PlayerHealToFull()
    {
        PlayerHUD.setHPFull(playerUnit);
        playerUnit.gainCurrentHealth();

        yield return new WaitForSeconds(2f);
    }

    IEnumerator PlayerBlessing()
    {
        string[] blessings = {"Double Attack", "Double Damage"};
        string randomBlessing = blessings[Random.Range(0, blessings.Length)];

        PlayerHUD.setBlessing(randomBlessing ,playerUnit);
        playerUnit.gainBlessing();

        yield return new WaitForSeconds(2f);
    }

    public void nextSceneEnd()
    {
        PlayerStats.roomCounter++;
        SceneManager.LoadScene("Battle");
    }

    IEnumerator PlayerMaxEnergyGain()
    {
        PlayerHUD.setMaxEnergy(1, playerUnit);
        dialogueText.text = "Player Max Energy is now: " + playerUnit.maxEnergy + "!";
        playerUnit.gainMaxEnergy();

        yield return new WaitForSeconds(2f);
    }
}
