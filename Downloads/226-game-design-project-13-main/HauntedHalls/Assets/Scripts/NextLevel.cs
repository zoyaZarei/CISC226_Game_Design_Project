using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject dialogue;
    private string[] cantProceed = { "Let's keep exploring, I have the feeling I'm missing something" };
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (SceneManager.GetActiveScene().name == "Level 1" && BossFightStart.twinsBeaten == false)
        {
            return;
        }
        if (SceneManager.GetActiveScene().name == "Level 3" && (!LoadManager.inv.Contains("necklace") || !LoadManager.inv.Contains("phone") || !LoadManager.inv.Contains("bag")))
        {
            dialogue.SetActive(true);
            dialogue.GetComponent<OneLineDialogue>().enabled = true;
            dialogue.GetComponent<OneLineDialogue>().Start();
            dialogue.GetComponent<OneLineDialogue>().StartDialogue(cantProceed);
            return;
        }

        if (other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
