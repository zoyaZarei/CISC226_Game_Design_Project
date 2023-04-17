using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBossFight : MonoBehaviour
{
    public GameObject finalBoss;
    public GameObject finalBossMain;
    public CameraPan PlayerCam;
    public GameObject player;
    public PlayerMovement playerMovement;
    public Animator animator;
    public GameObject phaseTwoBoss;
    private bool bossActivated = false;
    public GameObject bossHealthBar;
    public static bool PhaseTwo;
    public GameObject playerCam;
    public GameObject cameraTwo;

    public GameObject dialogue;
    public SwitchBody switchBody;


    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("lastX", 1);
        playerMovement.canMove = false;
        //PlayerCam.PanToTarget();

        //finalBoss = GameObject.Find("FinalBoss");
        //bossHealthBar = GameObject.Find("bossHealthBar");
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerCam.isPanning)
        {
            playerMovement.canMove = true;
        }

        else if (PlayerCam.isPanning)
        {
            playerMovement.canMove = false;
        }

        //Vector3 bossPosition = finalBoss.position;
        //Vector3 playerPosition = player.position;
        if (!bossActivated)
        {
            float distance = Vector3.Distance(player.transform.position, finalBoss.transform.position);
            if (distance <= 3)
            {
                activateBoss();
            }
        }

        if (finalBoss.GetComponent<FinalBossMain>().currentHealth <= 0 && !PhaseTwo)
        {
            dialogue.SetActive(true);
            dialogue.GetComponent<PrePhase2Dialogue>().enabled = true;
            if (PrePhase2Dialogue.dialogueComplete)
            {
                activatePhaseTwo();
            }
        }

        else if (finalBossMain.GetComponent<FinalBossMain>().currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }



    }

    void activateBoss()
    {
        MonoBehaviour[] scripts = finalBoss.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = true;
        }
        bossHealthBar.SetActive(true);
    }

    void activatePhaseTwo()
    {

        switchBody.resetHuman();
        player.transform.position = new Vector3(0f, -3f, 0f);

        int bossHealth = finalBoss.GetComponent<FinalBossMain>().currentHealth;
        phaseTwoBoss.SetActive(true);
        //finalBoss = phaseTwoBoss;
        PhaseTwo = true;
        GameObject.Find("FinalBoss").SetActive(false);
        //finalBoss.GetComponent<FinalBossMain>().currentHealth = bossHealth;
        phaseTwoBoss.GetComponent<FinalBossMain>().currentHealth = bossHealth;
        SwitchMainCamera();
    }

    void SwitchMainCamera()
    {
        cameraTwo.SetActive(true);
        playerCam.SetActive(false);
    }

}
