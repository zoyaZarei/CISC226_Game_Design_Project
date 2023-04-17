using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchBody : MonoBehaviour
{
    public Sprite ghost;
    public Sprite body;
    public Animator animator;
    public BoxCollider2D col;

    private float timer;
    public static bool canSwitch;

    public static bool inGhost = false;

    // For left behind body.
    public GameObject humanBody;
    public GameObject bodyLeft;
    public GameObject bodyRight;
    public Transform bodyPosition;
    public AudioSource switchToHuman;
    public AudioSource switchToGhost;
    public PlayerMovement playerMovement;

    private bool firstTeleport = false;
    public GameObject dialogue;
    private bool bodyExists = false;

    private string[] firstTeleportDialogue = { "Oops, looks like I went too far and returned to my body." };

    // To determine distance from body when in ghost form.
    public float distance;

    void Start()
    {
        canSwitch = true;
    }

    void Update()
    {
        if (Dialogue.canDoAction)
        {
            // Keep track of timer.
            if (!canSwitch)
            {
                timer += Time.deltaTime;
                if (timer > 0.4)
                {
                    timer = 0;
                    canSwitch = true;
                    Debug.Log("Can move");
                    playerMovement.canMove = true;
                    this.gameObject.GetComponent<PlayerMovement>().enabled = true;
                }
            }

            // Calculate distance from the left behind body if it exists.
            if (humanBody != null)
            {
                distance = (humanBody.transform.position - transform.position).magnitude;

                // If too far teleport back.
                if (distance > 8f)
                {
                    if (!firstTeleport && SceneManager.GetActiveScene().name == "Level 1")
                    {
                        dialogue.SetActive(true);
                        dialogue.GetComponent<OneLineDialogue>().enabled = true;
                        dialogue.GetComponent<OneLineDialogue>().Start();
                        dialogue.GetComponent<OneLineDialogue>().StartDialogue(firstTeleportDialogue);
                    }
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = body;
                    this.gameObject.transform.position = new Vector2(humanBody.transform.position.x, humanBody.transform.position.y);
                    Destroy(humanBody);
                    bodyExists = false;
                    inGhost = false;
                    firstTeleport = true;
                }
            }

            // If not in ghost, become ghost and leave behind body.
            if (Input.GetKey(KeyCode.Space) && inGhost == false && canSwitch && !bodyExists && humanBody == null)
            {
                this.gameObject.GetComponent<PlayerMovement>().enabled = false;
                inGhost = true;
                Debug.Log("Here");
                canSwitch = false;
                playerMovement.canMove = false;
                switchToGhost.Play();
                this.gameObject.GetComponent<SpriteRenderer>().sprite = ghost;

                if (animator.GetFloat("lastX") <= 0 || animator.GetFloat("lastX") == null)
                {
                    StartCoroutine(spawnBody(bodyLeft, bodyPosition));

                }
                else if (animator.GetFloat("lastX") > 0)
                {
                    StartCoroutine(spawnBody(bodyRight, bodyPosition));
                }
                timer = 0;

                /*                 if (animator.GetFloat("lastX") <= 0)
                                {
                                    humanBody = Instantiate(bodyLeft, bodyPosition);
                                }
                                else if (animator.GetFloat("lastX") > 0)
                                {
                                    humanBody = Instantiate(bodyRight, bodyPosition);
                                }
                                timer = 0; */

            }

            // If ghost and close to body, become human.
            else if ((distance <= 4.06f) && Input.GetKey(KeyCode.Space) && canSwitch && bodyExists)
            {
                this.gameObject.GetComponent<PlayerMovement>().enabled = false;
                inGhost = false;
                canSwitch = false;
                playerMovement.canMove = false;
                timer = 0;
                switchToHuman.Play();
                this.gameObject.GetComponent<SpriteRenderer>().sprite = body;
                this.gameObject.transform.position = new Vector2(humanBody.transform.position.x, humanBody.transform.position.y);
                Destroy(humanBody);
                bodyExists = false;
                timer = 0;
            }

            // for ghost animations.
            if (inGhost == false)
            {
                animator.SetBool("inGhost", false);
            }
            else if (inGhost == true)
            {
                animator.SetBool("inGhost", true);
            }
        }
    }

    IEnumerator spawnBody(GameObject body, Transform position)
    {
        yield return new WaitForSeconds(0.42f);
        humanBody = Instantiate(body, position);
        timer = 0;
        bodyExists = true;
    }

    public void resetHuman()
    {
        if (inGhost)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = body;
            this.gameObject.transform.position = new Vector2(humanBody.transform.position.x, humanBody.transform.position.y);
            Destroy(humanBody);
            bodyExists = false;
            inGhost = false;
        }

    }
}