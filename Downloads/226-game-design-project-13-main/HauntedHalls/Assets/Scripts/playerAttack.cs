using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public int attackRange = 1;
    public bool canAttack = true;
    public LayerMask enemyLayers;
    private float timer;
    public int damage;
    public AudioSource batSound;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dialogue.canDoAction)
        {
            if (!SwitchBody.inGhost)
            {
                if (!canAttack)
                {
                    timer += Time.deltaTime;
                    if (timer > 0.5)
                    {
                        timer = 0;
                        canAttack = true;

                    }
                }

                else if (Input.GetKey(KeyCode.Mouse0) && SwitchBody.inGhost == false)
                {
                    attack();
                    batSound.Play();
                    canAttack = false;
                }
            }
        }
    }

    void attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        if (hitEnemies != null)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy != null)
                {
                    Enemy enemyComponent = enemy.GetComponent<Enemy>();
                    if (enemyComponent != null && !enemyComponent.isGhost)
                    {
                        enemyComponent.TakeDamage(damage);
                    }
                }
            }

        }

    }
}
