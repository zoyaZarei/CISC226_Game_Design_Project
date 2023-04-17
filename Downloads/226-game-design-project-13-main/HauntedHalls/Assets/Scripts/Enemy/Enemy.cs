using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public enemyHealthBar healthBar;

    public bool isAlive = true;
    public bool isGhost;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    public void SetHealth(int health)
    {
        currentHealth = health;
    }

    void Die()
    {
        Debug.Log("Killed");
    }
}
