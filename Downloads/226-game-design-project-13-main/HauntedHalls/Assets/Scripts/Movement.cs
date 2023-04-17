using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float mvSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject player;
    public GameObject selfPos;
    
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate(){
       // rb.MovePosition(rb.position + movement * mvSpeed * Time.fixedDeltaTime);
       if (!SwitchBody.inGhost){
        transform.position = player.transform.position;
       }
       else{
        transform.position = selfPos.transform.position;
       }
    }

}
