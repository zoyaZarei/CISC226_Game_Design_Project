using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    [SerializeField] private float speed;
    public Animator animator;
    private Vector3 targetLocation;
    private Vector3 direction;
    private float movementDir;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        targetLocation = player.transform.position;
    }

    // Update is called once per frame
    void Update(){

        if (canMove)
        {
            targetLocation = player.transform.position;
            direction = (targetLocation - transform.position) * speed;
            movementDir = (targetLocation.x - transform.position.x);
            //transform.Translate(direction * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);
        }
        
        else if (!canMove)
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (movementDir != 0)
            {
                animator.SetFloat("lastX", movementDir);
            }
    }
}

