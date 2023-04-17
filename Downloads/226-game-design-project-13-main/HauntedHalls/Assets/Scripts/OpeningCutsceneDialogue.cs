using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OpeningCutsceneDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textComponent;
    public bool isRunning = false;
    public static bool canDoAction = true;
    private bool dialogueComplete;

    private float timer = 0;
    private bool canNextLine = true;

    // Text
    private int i;
    private string[] openingDialogue = {"I can't believe she's gone.",
                                        "My best friend.",
                                        "Kyra...",
                                        "I can't imagine what could have happened to her, but I know one thing for sure - I have to find her.",
                                        "All I can think about is her, and the fear that she might be in danger.",
                                        "This school... I can feel the negative energy just from standing out here",
                                        "I don't know what's causing it, but I just feel like it has something to do with her dissapearance.",
                                        "Kyra... Please be safe... I'm going to find you. I won't rest until I do."};

    public void Start()
    {
        dialogueComplete = false;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (i >= openingDialogue.Length)
        {
            dialogueComplete = true;
        }
        else
        {
            dialogueComplete = false;
            StartDialogue(openingDialogue);
        }


        if (Input.GetKey(KeyCode.Return) && dialogueComplete && canNextLine)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
