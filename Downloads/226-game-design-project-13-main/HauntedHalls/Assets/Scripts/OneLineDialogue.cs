using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OneLineDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textComponent;
    public bool isRunning = false;
    private bool dialogueComplete;
    private float timer = 0;
    private bool canNextLine = true;

    // Text

    public void Start()
    {
        dialogueComplete = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Cutscene after beating twins.
        if (Input.GetKey(KeyCode.Return))
        {
            Debug.Log("ENDED!");
            gameObject.SetActive(false);
            isRunning = false;
            Dialogue.canDoAction = true;
            textComponent.text = string.Empty;
            ResumeGame();
            this.enabled = false;
        }
    }

    public void StartDialogue(string[] dialogue)
    {
        PauseGame();
        Dialogue.canDoAction = false;
        DisplayText(dialogue[0]);
        //StartCoroutine(TypeLine(0));
    }

    void DisplayText(string dialogue){
        textComponent.text = dialogue;
    }

    public void hideDialogue()
    {
        gameObject.SetActive(false);
    }

    public void stopRunning()
    {
        isRunning = false;
    }

    void PauseGame ()
    {
        Time.timeScale = 0;
    }
    void ResumeGame ()
    {
        Time.timeScale = 1;
    }

    void OnEnable()
     {
        Debug.Log("TEXT ENABLEd");
        dialogueComplete = true;
     }
}
