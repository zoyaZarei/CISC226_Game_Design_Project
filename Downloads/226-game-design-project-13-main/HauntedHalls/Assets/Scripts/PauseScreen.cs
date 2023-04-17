using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pause;
    public GameObject controls;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Tab))
        {
            pause.SetActive(true);
            Dialogue.canDoAction = false;
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        Dialogue.canDoAction = true;
    }

    public void Controls()
    {
        controls.SetActive(true);
    }

    public void closeControls()
    {
        controls.SetActive(false);
    }


}
