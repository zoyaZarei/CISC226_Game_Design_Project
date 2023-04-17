using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightStart : MonoBehaviour
{
    public GameObject pianoHealthBar;
    public GameObject enemyHealthBar;
    public GameObject ghostTwin;
    public GameObject pianoTwin;
    public GameObject pianoEnemy;
    public GameObject pianoOutline;
    public GameObject ghostOutline;
    public Animator animator;
    public GameObject shadow;
    public GameObject pianoController;
    public GameObject player;

    public static bool encouterDialogueCompleted = true;
    public static bool twinsBeaten = false;
    public GameObject dialogue;
    public static bool dialogueCompleted = false;
    private string[] pianoDead = { "Twin 1: Oh no, you broke my piano :(" };

    private bool shownPianoDialogue = false;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    public GameObject MainCamera;
    public Camera cameraMechanics;
    private bool panned = false;
    private Vector3 initialPlayerPosition;
    private Vector3 targetPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        ghostTwin.gameObject.SetActive(true);
        pianoTwin.gameObject.SetActive(true);
        BossFightTwins.inBossFight = true;
        encouterDialogueCompleted = false;

        initialPosition = GameObject.Find("Main Camera").transform.position;
        targetPosition = initialPosition + (Vector3.down * 0.5f) + (Vector3.right);
        cameraMechanics = MainCamera.GetComponent<Camera>();
        StartCoroutine(Panning());
    }

    // Update is called once per frame
    void Update()
    {

        // Pre fight cutscene
        if (!encouterDialogueCompleted & panned)
        {
            dialogue.GetComponent<Dialogue>().enabled = true;
            dialogue.SetActive(true);
        }

        if (encouterDialogueCompleted && pianoTwin.activeSelf)
        {
            StartCoroutine(pianoTwinAnim());
            StartCoroutine(PanBack());
        }

        // turn off once dead.
        if (ghostTwin.GetComponent<Enemy>().currentHealth == 0)
        {
            ghostTwin.gameObject.SetActive(false);
            enemyHealthBar.gameObject.SetActive(false);
        }
        if (pianoEnemy.GetComponent<Enemy>().currentHealth == 0)
        {
            pianoEnemy.gameObject.SetActive(false);
            pianoHealthBar.SetActive(false);
            shadow.gameObject.SetActive(false);

            if (!shownPianoDialogue)
            {
                dialogue.SetActive(true);
                dialogue.GetComponent<OneLineDialogue>().enabled = true;
                dialogue.GetComponent<OneLineDialogue>().Start();
                dialogue.GetComponent<OneLineDialogue>().StartDialogue(pianoDead);
            }

            shownPianoDialogue = true;
        }
        if (ghostTwin.GetComponent<Enemy>().currentHealth == 0 && pianoEnemy.GetComponent<Enemy>().currentHealth == 0 && !dialogueCompleted)
        {
            BossFightTwins.inBossFight = false;
            twinsBeaten = true;
        }

        if (twinsBeaten && !dialogueCompleted)
        {
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().enabled = true;
        }
        else if (twinsBeaten && dialogueCompleted)
        {
            gameObject.SetActive(false);
        }

    }

    IEnumerator pianoTwinAnim()
    {
        animator.SetTrigger("intoPiano");
        yield return new WaitForSeconds(0.4f);
        pianoTwin.SetActive(false);
        pianoController.GetComponent<PianoMain>().attackStart();
    }

    IEnumerator Panning()
    {
        player.GetComponent<PlayerMovement>().canMove = false;
        float elapsedTime = 0;
        float duration = 1f;

        while (elapsedTime <= duration)
        {
            MainCamera.transform.position = Vector3.Lerp(initialPosition, targetPosition, (elapsedTime / duration));
            //Camera.main.orthographicSize = 2.3f/(elapsedTime/duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panned = true;
        //StartCoroutine(PanBack());
    }

    private IEnumerator PanBack()
    {
        float elapsedTime = 0;
        float duration = 0.5f;

        while (MainCamera.transform.position != initialPosition)
        {
            MainCamera.transform.position = Vector3.Lerp(targetPosition, initialPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        pianoHealthBar.gameObject.SetActive(true);
        enemyHealthBar.gameObject.SetActive(true);
        pianoOutline.gameObject.SetActive(true);
        ghostOutline.gameObject.SetActive(true);
        shadow.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.4f);
        player.GetComponent<PlayerMovement>().canMove = true;

    }
}
