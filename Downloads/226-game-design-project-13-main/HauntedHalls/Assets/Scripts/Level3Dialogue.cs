using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level3Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textComponent;
    public bool isRunning = false;
    private bool dialogueComplete;

    private float timer = 0;
    private bool canNextLine = true;

    // Text
    private int i;

    private string[] startingDialogue = {"I sense a lot of negative energy nearby. I don't have a good feeling about this...",
                                         };

    public void Start()
    {
        dialogueComplete = false;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Cutscene after beating twins.

        if (i >= startingDialogue.Length)
        {
            dialogueComplete = true;
        }
        else
        {
            dialogueComplete = false;
            StartDialogue(startingDialogue);
        }

        if (Input.GetKey(KeyCode.Return) && dialogueComplete && canNextLine)
        {
            i = 0;
            gameObject.SetActive(false);
            isRunning = false;
            Dialogue.canDoAction = true;
            textComponent.text = string.Empty;
            ResumeGame();
            this.enabled = false;
        }
        else if (Input.GetKey(KeyCode.Return) && canNextLine)
        {
            canNextLine = false;
            timer = 0;
            i++;
            Debug.Log(i);
        }

        if (!canNextLine)
        {
            timer += Time.unscaledDeltaTime;
            if (timer >= 0.3)
            {
                canNextLine = true;
            }
        }
    }

    public void StartDialogue(string[] dialogue)
    {
        PauseGame();
        Dialogue.canDoAction = false;
        DisplayText(dialogue[i]);
        //StartCoroutine(TypeLine(0));
    }

    void DisplayText(string dialogue)
    {
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

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    void OnEnable()
    {
        Debug.Log("TEXT ENABLEd");
        dialogueComplete = true;
        i = 0;
    }
}
