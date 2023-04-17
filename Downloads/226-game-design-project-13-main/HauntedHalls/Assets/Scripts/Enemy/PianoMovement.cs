using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoMovement : MonoBehaviour
{
    private GameObject player;
    private Vector3 targetLocation;
    private Vector3 direction;
    public bool falling = false;
    public bool isAlive = true;
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject piano;
    private bool followingPlayer;
    public bool inCollision = false;
    private float playerFound = 0;
    private GameObject playerBodyL;
    private GameObject playerBodyR;
    public GameObject shadow;
    //public GameObject logic;


    void Start()
    {
        player = GameObject.Find("Player");
        targetLocation = player.transform.position;
        followingPlayer = true;
        BoxCollider2D boxCollider = piano.GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }

    // Update is called once per frame
     void Update()
    {
        //bool pianoTwinIn = logic.GetComponent<BossFightStart>().pianoTwinIn;

       /*  if (pianoTwinIn)
        {
            followingPlayer = true;
        } */

        playerBodyL = GameObject.Find("playerBody L(Clone)");
        playerBodyR = GameObject.Find("playerBody R(Clone)");

        direction = (targetLocation - transform.position) * speed;
        if (followingPlayer == true)
        {
            if(playerBodyL != null){
                Debug.Log("following player");
                targetLocation = playerBodyL.transform.position;
            }
            else if(playerBodyR != null){
                Debug.Log("following player");
                targetLocation = playerBodyR.transform.position;
            }
            else{
                targetLocation = player.transform.position;
            }
            transform.Translate(direction * Time.deltaTime);
        }

        if (inCollision && playerFound >= 0.3)
        {
            followingPlayer = false;
            if(!falling){
                StartCoroutine(Fall());
                shadow.gameObject.SetActive(false);
                falling = true;
            }

        }
    }
    

    void OnTriggerStay2D(Collider2D col)
    {
        if (followingPlayer && ((col.tag == "Player" && SwitchBody.inGhost == false) || col.tag == "PlayerBody"))
        {
            inCollision = true;
            playerFound += Time.deltaTime;
            //falling = false;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if ((col.tag == "Player" && SwitchBody.inGhost == false)|| col.tag == "PlayerBody")
        {
            inCollision = false;
            playerFound = 0;
            //falling = false;
        }
    }

    IEnumerator Fall(){
        followingPlayer = false;
        yield return new WaitForSeconds(1);
        Vector3 startingPos = transform.position;
        Vector3 newPosition = new Vector3(startingPos.x, startingPos.y -2.0f, startingPos.z);
        float elapsedTime = 0;
        float duration = 0.5f;
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        falling=false;
        yield return new WaitForSeconds(2);

        elapsedTime = 0;
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(newPosition, startingPos, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        followingPlayer = true;
        shadow.gameObject.SetActive(true);
    }
}
