using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDamage : MonoBehaviour
{
    private GameObject player;
    public GameObject handController;
    [SerializeField]public int damage;
    public bool falling;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        falling = handController.GetComponent<HandMovements>().falling;
    }

    void OnTriggerEnter2D(Collider2D other){
        //Debug.Log("Bam");
        if (((other.tag == "Player" && SwitchBody.inGhost == false) 
        || other.tag == "PlayerBody") 
        && falling == true)
        {
            //Debug.Log("Bonk");
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
