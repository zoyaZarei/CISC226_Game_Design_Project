using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayerLocation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject playerBody;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LoadManager.visitedFinalLevel)
        {
            player.transform.position = new Vector3(4.96f, -2.72f, 0f);
            playerBody.transform.position = new Vector3(4.96f, -2.72f, 0f);
            LoadManager.visitedFinalLevel = false;
        }
    }
}
