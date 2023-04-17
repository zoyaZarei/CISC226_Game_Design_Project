using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockOverObjects : MonoBehaviour
{
    private bool triggerEntered = false;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true)
        {
            // transform.position = new Vector3(transform.position.x, transform.position.y, 70);
            // obj.transform.position = new Vector3(obj.position.x, obj.transform.position.y, -3);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        triggerEntered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        triggerEntered = false;
    }
}
