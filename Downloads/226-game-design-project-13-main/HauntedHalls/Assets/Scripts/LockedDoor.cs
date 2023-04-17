using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private bool locked = true;
    private bool nextToDoor = false;
    public GameObject dialogue;
    private string[] itsLocked = { "It's seems to be blocked by something... Maybe I should check out the other side using my ghost form?" };
    private string[] officeDoor = { "It's locked... Maybe I should check out the other side using my ghost form?" };
    private string[] itsUnlocked = { "The door seems to be unlocked now!" };
    private float timer;
    private bool canInteract;

    private bool cleared = false;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = true;
        canInteract = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dialogue.canDoAction)
        {
            if (ShelfClear.shelfCleared)
            {
                locked = false;
                cleared = true;
                if (gameObject.name != "Teacher's Office Door")
                {
                    gameObject.SetActive(false);
                }
            }

            if (SwitchBody.inGhost)
            {
                boxCollider.enabled = false;
            }
            else
            {
                if (cleared == false)
                {
                    boxCollider.enabled = true;
                }
                else
                {
                    boxCollider.enabled = false;
                    int defaultLayer = LayerMask.NameToLayer("Default");
                    gameObject.layer = defaultLayer;
                }

                if (!locked && Input.GetKey(KeyCode.E) && nextToDoor && canInteract)
                {


                    canInteract = false;
                    timer = 0;
                }
                else if (Input.GetKey(KeyCode.E) && nextToDoor && canInteract)
                {
                    dialogue.SetActive(true);
                    dialogue.GetComponent<OneLineDialogue>().enabled = true;
                    dialogue.GetComponent<OneLineDialogue>().Start();
                    if (gameObject.name != "Teacher's Office Door")
                    {
                        dialogue.GetComponent<OneLineDialogue>().StartDialogue(itsLocked);
                    }
                    else
                    {
                        dialogue.GetComponent<OneLineDialogue>().StartDialogue(officeDoor);
                    }

                    canInteract = false;
                    timer = 0;
                }
            }
        }

        if (!canInteract)
        {
            timer += Time.deltaTime;
            if (timer > 0.5)
            {
                canInteract = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !SwitchBody.inGhost)
        {
            nextToDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            nextToDoor = false;
        }
    }
}
