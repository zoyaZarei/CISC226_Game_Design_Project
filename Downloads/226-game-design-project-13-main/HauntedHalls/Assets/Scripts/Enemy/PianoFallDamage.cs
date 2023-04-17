using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoFallDamage : MonoBehaviour
{
    public GameObject player;
    public GameObject pianoPoint;
    [SerializeField] public int damage;
    public bool falling;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        falling = pianoPoint.GetComponent<PianoMovement>().falling;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (((other.tag == "Player" && SwitchBody.inGhost == false)
        || other.tag == "PlayerBody")
        && falling == true)
        {
            Debug.Log("Bonk");
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
