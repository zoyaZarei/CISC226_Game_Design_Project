using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactiveDistance = .5f;
    public LayerMask interactableObjects;
    public GameObject interact;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] interactObjects = Physics2D.OverlapCircleAll(transform.position, interactiveDistance, interactableObjects);

        if (interactObjects != null && interactObjects.Length > 0)
        {
            interact.SetActive(true);
        }
        else
        {
            interact.SetActive(false);
        }



    }
}
