using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    private bool canFire;
    private float timer;
    public Animator animator;

    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion flip = Quaternion.Euler(0, 180, 0);
        
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        /*rotZ = Mathf.Clamp(rotZ, -90f, 90f);

        Debug.Log(animator.GetFloat("lastX"));
        if(animator.GetFloat("lastX") > 0)
        {
            rotZ = Mathf.Clamp(rotZ, -90f, 90f);
        }
        
        else if(animator.GetFloat("lastX") < 0)
        {
            rotZ = Mathf.Clamp(rotZ, 90f, -90f);
        }*/

        transform.rotation = Quaternion.Euler(0,0,rotZ);

        if(!canFire){
            timer += Time.deltaTime;
            if(timer > 0.3){
                timer = 0;
                canFire = true;
            }
        }



        if(SwitchBody.inGhost && Input.GetKey(KeyCode.Mouse0) && canFire){
            canFire = false;
            animator.SetTrigger("Shoot");
            Instantiate(bullet, bulletTransform.position, bulletTransform.rotation);
        }
        
    }
}