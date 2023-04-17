using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 2;
    public LayerMask enemyLayer;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Debug.Log("BULLET COLLIDED!");
        if (collision.gameObject.tag == "Enemies") {
            //Debug.Log("enemy hit with bullet!");
            if (collision.gameObject != null) {
                Enemy enemyComponent = collision.gameObject.GetComponent<Enemy>();
                FinalBossMain bossComponent = collision.gameObject.GetComponent<FinalBossMain>();
                Phase2Main tearComponent = collision.gameObject.GetComponent<Phase2Main>();
                if (enemyComponent != null && enemyComponent.isGhost) {
                    //Debug.Log("here");
                    enemyComponent.TakeDamage(damage);
                    Destroy(this.gameObject);
                }
                else if(bossComponent != null && tearComponent == null)
                {
                    bossComponent.TakeDamage(damage);
                    Destroy(this.gameObject);
                }
                else if(bossComponent !=null && tearComponent.crying == true)
                {
                    bossComponent.TakeDamage(damage);
                    Destroy(this.gameObject);
                }
                else{
                    Destroy(gameObject);
                }
                
            }
        }

    }
}
