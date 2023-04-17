using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    private Inventory inventory;
    public Sprite item;
    public string pickedUpItem;
    public AudioSource sound;

    private bool triggerEntered = false;

    public GameObject dialogue;
    private string[] bagDialogue = { "This looks familiar... Could this be..." };
    private string[] phoneDialogue = { "It's familiar... Is this... Can it be....?" };
    private string[] necklaceDialogue = { "So familiar... No... It can't be..." };
    private string[] keyDialogue = { "A master key... This looks useful!" };

    private string[] cantPickUpDialogue = { "I can't pick things up in my ghost form" };

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true && !SwitchBody.inGhost)
        {
            sound.Play();
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    LoadManager.inv.Add(pickedUpItem);
                    switch (pickedUpItem)
                    {
                        case "bag":
                            LoadManager.bagIsPickedUp = true;
                            dialogue.SetActive(true);
                            dialogue.GetComponent<OneLineDialogue>().enabled = true;
                            dialogue.GetComponent<OneLineDialogue>().Start();
                            dialogue.GetComponent<OneLineDialogue>().StartDialogue(bagDialogue);
                            break;
                        case "phone":
                            LoadManager.phoneIsPickedUp = true;
                            dialogue.SetActive(true);
                            dialogue.GetComponent<OneLineDialogue>().enabled = true;
                            dialogue.GetComponent<OneLineDialogue>().Start();
                            dialogue.GetComponent<OneLineDialogue>().StartDialogue(phoneDialogue);
                            break;
                        case "necklace":
                            LoadManager.necklaceIsPickedUp = true;
                            dialogue.SetActive(true);
                            dialogue.GetComponent<OneLineDialogue>().enabled = true;
                            dialogue.GetComponent<OneLineDialogue>().Start();
                            dialogue.GetComponent<OneLineDialogue>().StartDialogue(necklaceDialogue);
                            break;
                        case "key":
                            dialogue.SetActive(true);
                            dialogue.GetComponent<OneLineDialogue>().enabled = true;
                            dialogue.GetComponent<OneLineDialogue>().Start();
                            dialogue.GetComponent<OneLineDialogue>().StartDialogue(keyDialogue);
                            break;
                        default:
                            break;
                    }
                    inventory.slots[i].GetComponent<Image>().sprite = item;
                    inventory.slots[i].GetComponent<Image>().color = new Color32(255, 255, 225, 255);
                    Destroy(gameObject);
                    break;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true && SwitchBody.inGhost)
        {
            dialogue.SetActive(true);
            dialogue.GetComponent<OneLineDialogue>().enabled = true;
            dialogue.GetComponent<OneLineDialogue>().Start();
            dialogue.GetComponent<OneLineDialogue>().StartDialogue(cantPickUpDialogue);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        triggerEntered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        triggerEntered = false;
    }


}
