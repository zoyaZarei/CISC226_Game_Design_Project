using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoMain : MonoBehaviour
{
    private PianoMovement movementScript;
    public GameObject piano;
    private pianoKeys pianoKeys;
    private GameObject BossFight;
    //public bool pianoTwinIn;
    public Animator animator;
    //public GameObject logic;
    
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = piano.gameObject.GetComponent<Renderer>();
        movementScript = GetComponent<PianoMovement>();
        BossFight = GameObject.Find("BossFight1");

        renderer.sortingOrder = 4;

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void attackStart()
    {
            gameObject.layer = LayerMask.NameToLayer("Enemies");
            piano.layer = LayerMask.NameToLayer("Enemies");
            piano.GetComponent<Renderer>().sortingOrder = 6;

            if (movementScript.enabled == false){
                movementScript.enabled = !movementScript.enabled;
            }

            Enemy enemy = piano.GetComponent<Enemy>();
            enemy.enabled = !enemy.enabled;
            animator.SetTrigger("attackStart");

    }
}
