using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBody : MonoBehaviour
{
    public Sprite ghost;
    public Sprite body;
    public bool inGhost = false;
    public GameObject humanBody;
    public GameObject bodyPrefab;
    public Transform bodyPosition;

    [SerializeField] Transform point;
    float distance;


    void Update()
    {
        distance = (point.transform.position - transform.position).magnitude;
        if (Input.GetKey(KeyCode.Space) && inGhost == false){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ghost;
            humanBody = Instantiate(bodyPrefab, bodyPosition);
            inGhost = true;
            System.Threading.Thread.Sleep(75);
        }
        else if (distance <= 5f && Input.GetKey(KeyCode.Space)){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = body;
            Destroy(humanBody);
            inGhost = false;
            System.Threading.Thread.Sleep(75);
        }
    }
}
