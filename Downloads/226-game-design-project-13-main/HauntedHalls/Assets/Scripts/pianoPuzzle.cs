using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class pianoPuzzle : MonoBehaviour
{
    //public bool enemyTrigger = false;
    public float interactiveDistance;
    public GameObject player;
    public GameObject interact;
    public GameObject puzzle;
    private pianoKeys pianoKeys;

    public PlayerMovement playerMovement;

    public playerAttack attack;
    private bool enemyTrigger;
    public GameObject dialogue;
    private string[] interactDialogue = { "I can't play the piano as a ghost" };

    // Start is called before the first frame update
    void Start()
    {
        // ACCESSING PIANOKEYS
        Transform keysTransform = puzzle.transform.Find("Piano");

        // Get a reference to the child game object using the child's transform
        GameObject piano = keysTransform.gameObject;

        // Get a reference to a component on the child game object
        pianoKeys = piano.GetComponent<pianoKeys>();

    }

    // Update is called once per frame
    void Update()
    {
        enemyTrigger = pianoKeys.enemyTrigger;
        if (!enemyTrigger)
        {
            openPuzzle();
        }

        else
        {
            interact.gameObject.SetActive(false);
        }
    }

    void openPuzzle()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < interactiveDistance && !SwitchBody.inGhost)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                puzzle.gameObject.SetActive(true);

                int defaultLayer = LayerMask.NameToLayer("Default");
                gameObject.layer = defaultLayer;
            }
            attack.canAttack = false;
        }
        else if (Vector3.Distance(this.transform.position, player.transform.position) < interactiveDistance && SwitchBody.inGhost)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogue.SetActive(true);
                dialogue.GetComponent<OneLineDialogue>().enabled = true;
                dialogue.GetComponent<OneLineDialogue>().Start();
                dialogue.GetComponent<OneLineDialogue>().StartDialogue(interactDialogue);
            }
        }


        else
        {
            puzzle.gameObject.SetActive(false);
            attack.canAttack = true;
            int defaultLayer = LayerMask.NameToLayer("InteractableObjects");
            gameObject.layer = defaultLayer;
        }

    }
}
