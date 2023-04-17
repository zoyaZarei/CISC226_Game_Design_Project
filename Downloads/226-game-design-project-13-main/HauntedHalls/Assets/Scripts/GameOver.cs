using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public HealthBar healthbar;
    public enemyHealthBar ghostHealthbar;

    public bossHealthBar finalBossHealthbar;
    public GameObject dialogue;

    public PlayerHealth playerHealth;
    public Enemy ghostHealth;

    public FinalBossMain finalBossHealth1;
    public FinalBossMain finalBossHealth2;
    public SwitchBody switchBody;
    private string[] deathDialogue;
    private string[] deathDialogue2 = { "I have to keep going...Kyra needs me." };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string builder = "Twin 2: You died " + Level1Save.deathCounter + " times? That's a skill issue haha";
        if (Level1Save.deathCounter == 1)
        {
            deathDialogue = new string[] { "Twin 1: Hahaha you really died?" };
        }
        else if (Level1Save.deathCounter == 2)
        {
            deathDialogue = new string[] { "Twin 2: You died again?" };
        }
        else if (Level1Save.deathCounter == 3)
        {
            deathDialogue = new string[] { "Twin 1: I'm getting bored..." };
        }
        else
        {
            deathDialogue = new string[] { builder };
        }
    }

    public void Reset()
    {
        Level1Save.deathCounter++;
        healthbar.SetHealth(100);
        playerHealth.SetHealth(100);
        switchBody.resetHuman();

        dialogue.SetActive(true);
        dialogue.GetComponent<OneLineDialogue>().enabled = true;
        dialogue.GetComponent<OneLineDialogue>().Start();

        if (SceneManager.GetActiveScene().name == "Level 1" && !BossFightStart.twinsBeaten)
        {
            ghostHealthbar.SetHealth(500);
            ghostHealth.SetHealth(500);
            dialogue.GetComponent<OneLineDialogue>().StartDialogue(deathDialogue);
        }
        else if (SceneManager.GetActiveScene().name == "FinalBossFight")
        {
            if (FinalBossFight.PhaseTwo)
            {
                finalBossHealth2.SetHealth(500);
            }
            else
            {
                finalBossHealth1.SetHealth(500);
            }
            finalBossHealthbar.SetHealth(500);
            dialogue.GetComponent<OneLineDialogue>().StartDialogue(deathDialogue2);
        }

        gameObject.SetActive(false);
    }
}
