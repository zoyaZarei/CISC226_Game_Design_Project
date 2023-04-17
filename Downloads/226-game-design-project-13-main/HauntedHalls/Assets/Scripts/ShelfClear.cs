using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfClear : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool shelfCleared = false;
    private GameObject player;
    private bool triggerEntered = false;
    public Transform shelfTransform;
    public float distance = 10;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true && SwitchBody.inGhost && !shelfCleared)
        {
            shelfCleared = true;
            this.gameObject.transform.position = new Vector3(5.66f, -2.9f, 0f);
            int defaultLayer = LayerMask.NameToLayer("Default");
            gameObject.layer = defaultLayer;
            // transform.position = new Vector2(transform.position.x, transform.position.y + distance);
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
