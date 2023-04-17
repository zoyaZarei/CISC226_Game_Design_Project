using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image Fill;
    public GameObject enemy;
    private float yOffset = 0.7f;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    void Update()
    {
        //transform.position = enemy.transform.position + Vector3.up * yOffset;
        transform.position  = Camera.main.WorldToScreenPoint(enemy.transform.position + Vector3.up * yOffset);

    }
}