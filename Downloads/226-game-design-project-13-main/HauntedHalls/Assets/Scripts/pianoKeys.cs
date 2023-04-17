using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class pianoKeys : MonoBehaviour
{
    public List<string> keyList;
    private List<string> targetList = new List<string>() { "R", "O", "Y", "B" };
    //public bool solved = false;
    private int pressed = 0;
    public GameObject pianoPuzzle;

    public bool enemyTrigger = false;
    public BossFightStart bossFightStart;

    public GameObject dialogue;
    private string[] wrongDialogue = { "That doesn't seem right... Maybe I should look around." };

    // Start is called before the first frame update
    void Start()
    {
        keyList.Clear();
    }

    void Update()
    {


        if (keyList.SequenceEqual(targetList))
        {
            keyList.Clear();
            pianoPuzzle.gameObject.SetActive(false);
            enemyTrigger = true;
            bossFightStart.enabled = !bossFightStart.enabled;
        }

        else if (pressed >= 4 && !keyList.SequenceEqual(targetList))
        {
            wrongCombo();
            pressed = 0;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            pianoPuzzle.gameObject.SetActive(false);
        }
    }

    public void wrongKey()
    {

        keyList.Clear();
        pressed++;


    }

    public void redKey()
    {


        keyList.Add("R");
        pressed++;

    }

    public void orangeKey()
    {
        keyList.Add("O");
        pressed++;


    }

    public void yellowKey()
    {

        keyList.Add("Y");
        pressed++;

    }

    public void blueKey()
    {
        keyList.Add("B");
        pressed++;
    }

    public void wrongCombo()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<OneLineDialogue>().enabled = true;
        dialogue.GetComponent<OneLineDialogue>().Start();
        dialogue.GetComponent<OneLineDialogue>().StartDialogue(wrongDialogue);
        keyList.Clear();
    }


}
