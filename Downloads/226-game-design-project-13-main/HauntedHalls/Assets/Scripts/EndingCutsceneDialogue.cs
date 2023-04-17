using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndingCutsceneDialogue : MonoBehaviour
{
    /// Start is called before the first frame update
    public TextMeshProUGUI textComponent;
    public bool isRunning = false;
    public static bool canDoAction = true;
    private bool dialogueComplete;
    public GameObject blackScreen;
    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;

    private float timer = 0;
    private bool canNextLine = true;

    // Text
    private int i;
    private string[] endingDialogue = {"-The monstrosity falls onto the roof, defeated-",
                                       "-It slowly dissipates leaving behind a small ghost-",
                                       "Alia: Kyra!!!",
                                       "Kyra: mmm... What just happened...?",
                                       "Alia: *sob* you were a scary ghost and I *sob*... I thought I lost you forever.",
                                       "Kyra: Alia... I'm sorry... I'm right here.",
                                       "-Kyra envelops Alia in a hug, trying to comfort her-",
                                       "Alia: I'm sorry... I'm so sorry... I couldn't save you.",
                                       "Kyra: But you did save me... I turned into an evil ghost and you brought me back.",
                                       "Alia: But... you're still dead...",
                                       "Kyra: But I'm here with you right now, aren't I?",
                                       "-Kyra gives Alia a big smile. Alia through her tears let's out a small laugh-",
                                       "Alia: Even through all this you can smile.",
                                       "Kyra: Cause I just found out my bestie has some superhero powers!",
                                       "Alia: Is that really whats keeping you up?",
                                       "Kyra: And well... Even now I get to be with you.",
                                       "-Theres a pause, the atmosphere is almost serene. The two friends reuinited again-",
                                       "-The end-"};

    public void Start()
    {
        dialogueComplete = false;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (i >= endingDialogue.Length)
        {
            dialogueComplete = true;
        }
        else
        {
            dialogueComplete = false;
            StartDialogue(endingDialogue);
        }
        
        if (i == 2)
        {
            blackScreen.SetActive(false);
            scene1.SetActive(true);
        }

        if (i == 4)
        {
            scene1.SetActive(false);
            scene2.SetActive(true);
        }

        if (i == 6)
        {
            scene2.SetActive(false);
            scene3.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Return) && dialogueComplete && canNextLine)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
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
        canDoAction = false;
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

