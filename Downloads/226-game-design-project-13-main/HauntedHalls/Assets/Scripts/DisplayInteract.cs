using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayInteract : MonoBehaviour
{
    public Sprite interact;
    public LayerMask objectLayers;
    public static Collider2D[] inRangeItems;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        inRangeItems = Physics2D.OverlapCircleAll(player.transform.position, 0.0001f , objectLayers);
        if (inRangeItems.Length > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = interact;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    
}
