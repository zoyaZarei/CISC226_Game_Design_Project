using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
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
    private string[] TwinsEncounterDialogue = {"Twin 1 and Twin 2: BOO!",
                                               "Twin 1: You have fallen into our trap!",
                                               "Twin 2: There’s no escape now!",
                                               "Alia: um... I don’t have time for this, would you happen to know anyth-",
                                               "Twin 1: Geez you could at least pretend to be scared, what a bummer...",
                                               "Twin 2: Wait a sec bro... She can see us, she just spoke directly to us.",
                                               "Twin 1: Huh?! Wait, you're right! You can see us?",
                                               "Alia: Yes I can but it’s a long story, so could you just ans-",
                                               "Twin 1: Yo this is wicked!",
                                               "Twin 2: Yeah it’ll be way more fun to play when she can see us!",
                                               "Alia: Hey! Listen to what I’m trying to say!",
                                               "Twin 1: Hmmmm... Maybe we’ll listen if you can beat us!",
                                               "Twin 2: Hehehe, here we come!!",
                                               "Alia: I guess I don’t have a choice here...",
                                               "Remember, I can attack (using LEFT-CLICK). I should attack enemies with a red outline using physical attacks and a white outline using ghost attacks."
                                               };
    private string[] TwinsBeatenDialogue = {"Twin 1: THAT. WAS. EPIC!!!",
                                            "Twin 2: Yeah! We haven't had fun like that in ages!",
                                            "Alia: ARE YOU TWO INSANE!!! YOU JUST TRIED TO KILL ME!!",
                                            "Twin 1: What are you talking about?",
                                            "Twin 2: Yeah you’re not actually human are you?",
                                            "Alia: I am human...",
                                            "Twin 1: Oh you should’ve told us earlier then.",
                                            "Alia: Maybe if you would just listen...",
                                            "Twin 1 and Twin 2: We’re sorry :(",
                                            "Alia: It’s fine... Could you please just answer my question now?",
                                            "Twin 1: I guess we said we’d do that didn’t we… Okay fine, but just one.",
                                            "Alia: So do either of you know anything about the disappearance of a girl, my age?",
                                            "Twin 1: Hmmmm... Nope, don't ring a bell.",
                                            "Twin 2: But there has been a large spike in evil energy recently.",
                                            "Alia: Really?! Where? ",
                                            "Twin 1: Hey hey the deal was to answer one question.",
                                            "Twin 2: Yeah, and that energy is way too dangerous to try and deal with anyways.",
                                            "Alia: I’m sure I can handle it, I’ve dealt with evil spirits before.",
                                            "Twin 1: I don’t think you understand, even with those powers you could be killed.",
                                            "Twin 2: Personally, I wouldn’t even go near it.",
                                            "Alia: But this must have something to do with the disappearance of my friend! Please just tell me where it’s coming from.",
                                            "Twin 1: *sigh* Okay we’ll tell you but this is our last warning, that thing isn’t going to show mercy.",
                                            "Alia: I can handle it. Just tell me.",
                                            "Twin 2: It’s coming from the roof.",
                                            "Alia: Okay thank you... I uh... really appreciate the help.",
                                            "Twin 1: Its no problem really, we had a lot of fun, so we were hoping you'd play some more...",
                                            "Twin 2: Yeah... it's why we really don't want you to get hurt...",
                                            "Alia: Listen... I promise that I won't get hurt. Once I save my friend, maybe we can play again... Well, if you promise to be more careful this time.",
                                            "Twin 1: We'll be more careful this time!",
                                            "Twin 2: We promise! And you promise to be safe!",
                                            "Alia: Of course. Once I find Kyra, we can all gve fun together!",
                                            "Twin 1 and 2: Sounds like a plan!",
                                            "Twin 2: There's a door to the right which leads upstairs. Good luck!!"
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
        if (BossFightStart.twinsBeaten)
        {
            if (i >= TwinsBeatenDialogue.Length)
            {
                dialogueComplete = true;
                BossFightStart.dialogueCompleted = true;
            }
            else
            {
                dialogueComplete = false;
                StartDialogue(TwinsBeatenDialogue);
            }
        }
        // Cutscene before fighting twins.
        else if (!BossFightStart.encouterDialogueCompleted)
        {
            if (i >= TwinsEncounterDialogue.Length)
            {
                dialogueComplete = true;
                BossFightStart.encouterDialogueCompleted = true;
            }
            else
            {
                dialogueComplete = false;
                StartDialogue(TwinsEncounterDialogue);
            }
        }

        if (Input.GetKey(KeyCode.Return) && dialogueComplete && canNextLine)
        {
            i = 0;
            gameObject.SetActive(false);
            isRunning = false;
            canDoAction = true;
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
