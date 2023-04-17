using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class EnemyShooting : MonoBehaviour {
    public GameObject bulletPrefab;
    private float timer = 0;
    
    
    // Update is called once per frame
    void Update(){
        timer += Time.deltaTime;
        float attackDistance = 5;
        GameObject player = GameObject.Find("Player");
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist <= attackDistance && timer > 1){
            timer = 0;
            FireRoutine();
        }
    }
    
    void FireRoutine()
    {
        // yield return new WaitForSeconds(fireInterval);
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
