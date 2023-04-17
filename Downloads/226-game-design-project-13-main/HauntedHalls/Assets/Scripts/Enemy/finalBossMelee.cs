using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalBossMelee : MonoBehaviour
{
    private float enemyCooldown;
    public int damage;
    public PlayerHealth playerHealth;

    private bool playerInRange = false;
    private bool canAttack = true;
    private float timer;
    private GameObject ScreamPoint;
    private GameObject Enemy;
    private float dist;
    private float attackDistance;

    void Start()
    {
        canAttack = true;
        enemyCooldown = 2.0f;
        timer = 0;
        ScreamPoint = GameObject.Find("ScreamSource");
        attackDistance = 1;
        //Enemy = GameObject.Find("FinalBoss");
    }

    private void Update()
    {
        timer += Time.deltaTime;

        GameObject player = GameObject.Find("Player");
        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist <= attackDistance)
        {
            playerInRange = true;
        }
        else if (dist > attackDistance)
        {
            playerInRange = false;
        }

        if (playerInRange && canAttack)
        {
            StartCoroutine(Attacking());
        }

        else if (canAttack && !playerInRange && timer >= 10)
        {
            //Debug.Log("Pew");
            canAttack = false;
            enemyCooldown = 2.0f;
            timer = 0;
            ScreamPoint.GetComponent<finalBossScream>().Scream();
            //Debug.Log("Here");
            StartCoroutine(AttackCooldown(5.0f));

        }
    }
    IEnumerator Attacking()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.3f);
        if (dist <= attackDistance)
        {
            playerHealth.TakeDamage(damage);

            //Debug.Log("Hit");
            enemyCooldown = 5.0f;
            timer = 0;
            StartCoroutine(AttackCooldown(2.0f));
        }
        else
        {
            canAttack = true;
        }
    }

    IEnumerator AttackCooldown(float enemyCooldown)
    {
        while (enemyCooldown > 0)
        {
            enemyCooldown -= Time.deltaTime;
            canAttack = false;
            yield return null;
        }
        if (enemyCooldown <= 0){
            canAttack = true;
        }
    }
}
