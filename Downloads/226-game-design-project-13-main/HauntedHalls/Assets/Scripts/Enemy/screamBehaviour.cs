using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screamBehaviour : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 10;
    private Vector2 velocity;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    public void SpawnBullet(Vector3 position, Quaternion rotation)
    { 
        transform.position = position;
        transform.rotation = rotation;
        velocity = transform.right.normalized * MovementSpeed;
    }

    public void Update()
    {
        Vector2 nextPosition = (Vector2)transform.position + (velocity * Time.deltaTime);
        transform.position = nextPosition;

        Destroy(gameObject, 5f);
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
