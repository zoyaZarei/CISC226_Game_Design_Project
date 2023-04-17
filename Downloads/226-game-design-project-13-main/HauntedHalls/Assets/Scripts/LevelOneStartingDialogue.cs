using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelOneStartingDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textComponent;
    public bool isRunning = false;
    private bool dialogueComplete;

    private float timer = 0;
    private bool canNextLine = true;

    // Text
    private int i;
    private string[] levelOneDialogue = {"The kids in my class recently have been talking about how the piano in the music room will play itself.",
                                        "The music room is at the end of the hall, maybe I should go investigate it.",
                                        "If there are ghosts maybe they would know something about Kyra.",
                                        "With my powers this shouldn't be an issue, using my ghost form will be useful here.",
                                        "If I need to get through walls, I can just just leave my body behind (by pressing SPACE) and use my ghost to walk through.",
                                        "I need to be careful though, if I get too far my spirit returns to my body.",
                                        "I can also possess some items if they get in my way. (by pressing E)",
                                        "And if any nasty spirits come I can beat them with my bat or use my ghost form's bullets (by pressing LEFT-CLICK) to take them down.",
                                        "If I forget, I can bring up a reminder (by pressing TAB)",
                                        "Let's start exploring (WASD to move).",
                                        "I'm on my way Kyra, please just stay safe...."};

    public void Start()
    {
        dialogueComplete = false;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Cutscene after beating twins.
        if (i >= levelOneDialogue.Length)
        {
            dialogueComplete = true;
        }
        else
        {
            dialogueComplete = false;
            StartDialogue(levelOneDialogue);
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

