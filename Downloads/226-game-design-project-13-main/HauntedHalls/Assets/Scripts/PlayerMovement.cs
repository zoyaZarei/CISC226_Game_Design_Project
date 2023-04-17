using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float mvSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public AudioSource footstepsSound;
    public bool canMove = true;

    Vector2 movement;

    void Start()
    {
        animator.SetFloat("lastX",1f);
    }
    // Update is called once per frame
    void Update()
    {
        if(Dialogue.canDoAction && canMove)
        {
        
            if (SwitchBody.canSwitch)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");

                if (movement.x != 0 /* || movement.y != 0 */)
                {
                    footstepsSound.enabled = true;
                    animator.SetFloat("lastX", movement.x);
                }
                
                else if(movement.y != 0)
                {
                    footstepsSound.enabled = true;
                }

                else
                {
                    footstepsSound.enabled = false;
                }


                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
            }
        }

    }

    void FixedUpdate()
    {
        if(Dialogue.canDoAction && canMove)
        {
            rb.MovePosition(rb.position + movement * mvSpeed * Time.fixedDeltaTime);
        }
    }

}
