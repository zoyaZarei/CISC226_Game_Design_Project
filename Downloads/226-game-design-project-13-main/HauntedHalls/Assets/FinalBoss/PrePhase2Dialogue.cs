using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrePhase2Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textComponent;
    public bool isRunning = false;
    public static bool dialogueComplete;

    private float timer = 0;
    private bool canNextLine = true;

    public GameObject dialogueObject;

    // Text
    private int i;
    private string[] prePhase2Dialogue = {"???: Urghhh...",
                                          "Alia: Who are you...?",
                                          "???: .... *sob*",
                                          "Alia: It can't be can it... are you.... Kyra?",
                                          "???: ..... Alia? Is that you?",
                                          "Alia: Kyra! No! What happened to you?!",
                                          "Kyra: Why am I like this? I don't understand... Why? Why? Why?",
                                          "Alia: Kyra please calm down... I... I don't want this to be true...",
                                          "Kyra: Alia please help me... Why am I like this?! This must be some nightmare...",
                                          "Alia: .... Kyra.... You're dead... I don't want it to be true but... It's the only explanation.",
                                          "Kyra: No... It can't be... Why would I be dead? You're right in front of me talking to me... So how can I be dead...?",
                                          "Alia: Kyra... I'm sorry *sob* I couldn't save you.",
                                          "Kyra: No you're lying... This isn't true... This isn't real... You said we'd always be together... You... You lied to me!",
                                          "Alia: Kyra no! I am here for you!",
                                          "Kyra: No no no no no! You are just a liar!",
                                          "-Kyra's ghost begins emitting a large amount of evil energy, Alia freezes unable to act as she watches her former friend transform into something even more monstrous-",
                                          "Alia: I'm sorry Kyra... That I couldn't save you... I guess this is the end..."};

    public void Start()
    {
        dialogueComplete = false;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Cutscene after beating twins.
        if (i >= prePhase2Dialogue.Length)
        {
            dialogueComplete = true;
            // Debug.Log("entered here");
        }
        else
        {
            dialogueComplete = false;
            StartDialogue(prePhase2Dialogue);
        }

        if (Input.GetKey(KeyCode.Return) && dialogueComplete && canNextLine)
        {
            i = 0;
            gameObject.SetActive(false);
            isRunning = false;
            Dialogue.canDoAction = true;
            textComponent.text = string.Empty;
            ResumeGame();
            dialogueObject.SetActive(false);
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
        // Debug.Log("TEXT ENABLEd");
        // dialogueComplete = true;
        i = 0;
    }
}
