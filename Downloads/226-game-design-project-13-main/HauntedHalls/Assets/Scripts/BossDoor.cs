using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    private GameObject player;
    private BoxCollider2D boxCollider;
    public GameObject dialogue;
    private string[] itsLocked = { "It's locked... Maybe there's a key somewhere around here." };
    private string[] itsUnlocked = { "The key I found fits! It's unlocked now." };
    private bool hasKey;
    private bool nextToDoor = false;
    private float timer;
    private bool canInteract;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = true;
        canInteract = true;
    }

    // Update is called once per frame
    void Update()
    {
        hasKey = LoadManager.inv.Contains("key");
        if (BossFightTwins.inBossFight)
        {
            boxCollider.enabled = true;
        }
        else if (hasKey && Input.GetKeyDown(KeyCode.E) && nextToDoor)
        {
            boxCollider.enabled = false;
            dialogue.SetActive(true);
            dialogue.GetComponent<OneLineDialogue>().enabled = true;
            dialogue.GetComponent<OneLineDialogue>().Start();
            dialogue.GetComponent<OneLineDialogue>().StartDialogue(itsUnlocked);
        }
        else if (Input.GetKey(KeyCode.E) && nextToDoor && canInteract)
        {
            dialogue.SetActive(true);
            dialogue.GetComponent<OneLineDialogue>().enabled = true;
            dialogue.GetComponent<OneLineDialogue>().Start();
            dialogue.GetComponent<OneLineDialogue>().StartDialogue(itsLocked);
            canInteract = false;
            timer = 0;
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

