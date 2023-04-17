using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    public PlayerHealth playerHealth;
    private Vector3 targetPlayer;
    [SerializeField] private float speed = 5f;
    private Vector3 direction;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //null check into get current target location
        if (player != null)
        {
            targetPlayer = player.transform.position;
        }
        else
        {
            Debug.LogError("EnemyShot.player is NULL");
        }
        //calculate direction to move (normalized scales values of vector to be max 1)
        direction = (targetPlayer - transform.position).normalized * speed;

        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && SwitchBody.inGhost)
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
