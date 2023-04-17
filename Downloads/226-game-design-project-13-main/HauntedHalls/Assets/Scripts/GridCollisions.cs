using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCollisions : MonoBehaviour
{
    public Collider2D col;

    // Update is called once per frame
    void Update()
    {
        if (BossFightTwins.inBossFight) {
            col.enabled = true;
        }
        else if(SwitchBody.inGhost){
            col.enabled = false;
        }
        else{
            col.enabled = true;
        }
        
    }
}
