using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float enemyCooldown = 1;
    public int damage = 1;
    public PlayerHealth playerHealth;

    private bool playerInRange = false;
    private bool canAttack = true;

    private void Update()
    {
        float attackDistance = 1;
        GameObject player = GameObject.Find("Player");
        float dist = Vector3.Distance(player.transform.position, transform.position);

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
            playerHealth.TakeDamage(damage);
            // player.GetComponent<PlayerHealth>().currentHealth -= damage;

            // KNOCKBACK
            /* float lastX = player.GetComponent<Animator>().GetFloat("lastX");

            if (lastX > 0){
                player.GetComponent<Transform>().Translate(Vector2.left);
            }

            else if(lastX < 0){
                player.GetComponent<Transform>().Translate(Vector2.right);
            } */
            player.GetComponent<PlayerHealth>().TakeDamage(10);

            Debug.Log("Hit");
            StartCoroutine(AttackCooldown());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(enemyCooldown);
        canAttack = true;
    }
}
