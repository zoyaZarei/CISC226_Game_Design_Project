using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2Main : MonoBehaviour
{
    private float tearTimer;
    private float tearDuration;
    public GameObject tearController;
    public GameObject handController;
    private Vector3 RHandPos;
    private Vector3 LHandPos;
    public Animator animator;
    public bool crying = false;
    public GameObject outline;

    // Start is called before the first frame update
    void Start()
    {
        tearTimer = 0;
        tearDuration = 0;
        RHandPos = new Vector3(11,-8,0);
        LHandPos = new Vector3(-11,-8,0);
    }

    // Update is called once per frame
    void Update()
    {
        tearTimer += Time.deltaTime;
        tearDuration += Time.deltaTime;

        // If tears aren't currently active, check if it's been long enough to trigger them
        if (!tearController.activeSelf){
            float target = Random.Range(20f,50f);
            if (tearTimer >= target)
            {
                //Debug.Log("Starting tears");
                BeginTears();
                StopHands();
            }
        }
        
        // If tears are active and tearDuratiin has been met
        if (tearController.activeSelf && tearDuration >= 20f){
            //Debug.Log("Stopping tears");
            StopTears();
            StartHands();
        }
    }

    void BeginTears()
    {
        crying = true;
        animator.SetBool("Cry", true);
        outline.SetActive(true);
        tearController.gameObject.SetActive(true);
        tearTimer = 0;
        tearDuration = 0;
    }

    void StopTears()
    {
        crying = false;
        animator.SetBool("Cry", false);
        outline.SetActive(false);
        tearController.gameObject.SetActive(false);
        tearTimer = 0;
        tearDuration = 0;
    }

    void StartHands()
    {
        handController.gameObject.SetActive(true);
    }

    void StopHands()
    {
        GameObject RHand = GameObject.Find("RPoint");
        RHand.transform.position = RHandPos;
        GameObject LHand = GameObject.Find("LPoint");
        LHand.transform.position = LHandPos;
        
        handController.gameObject.SetActive(false);
    }
}
