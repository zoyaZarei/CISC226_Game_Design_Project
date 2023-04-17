using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovements : MonoBehaviour
{
    private GameObject player;
    public CameraShake camera;
    private Vector3 targetLocation;
    private Vector3 direction;
    public bool falling = false;
    public bool isAlive = true;
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject hand;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    public Animator animator;
    private bool followingPlayer;
    public bool inCollision = false;
    private float playerFound = 0;
    private GameObject playerBodyL;
    private GameObject playerBodyR;


    void Start()
    {
        player = GameObject.Find("Player");
        targetLocation = player.transform.position;
        followingPlayer = true;
    }

    // Update is called once per frame
     void Update()
    {
        playerBodyL = GameObject.Find("playerBody L(Clone)");
        playerBodyR = GameObject.Find("playerBody R(Clone)");

        direction = (targetLocation - transform.position) * speed;
        if (followingPlayer == true)
        {
            if(playerBodyL != null){
                targetLocation = playerBodyL.transform.position;
            }
            else if(playerBodyR != null){
                targetLocation = playerBodyR.transform.position;
            }
            else{
                targetLocation = player.transform.position;
            }

            float targetX = targetLocation.x;
            float targetY = targetLocation.y;

            if (targetX > minX && targetX < maxX && targetY > minY && targetY < maxY)
            {
                transform.Translate(direction * Time.deltaTime);
            }
        }

        if (inCollision && playerFound >= 0.8f)
        {
            followingPlayer = false;
            if(!falling){
                StartCoroutine(Fall());
                falling = true;
            }

        }
    }
    
    void OnTriggerStay2D(Collider2D col)
    {
        //Debug.Log("Found");
        if(followingPlayer)
        {
            if ((col.tag == "Player" && SwitchBody.inGhost == false)|| col.tag == "PlayerBody")
            {
                //Debug.Log("Detected");
                inCollision = true;
                playerFound += Time.deltaTime;
            }
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if ((col.tag == "Player" && SwitchBody.inGhost == false)|| col.tag == "PlayerBody")
        {
            inCollision = false;
            playerFound = 0;
        }
    }

    IEnumerator Fall(){
        followingPlayer = false;
        yield return new WaitForSeconds(1);
        Vector3 startingPos = transform.position;
        Vector3 newPosition = new Vector3(startingPos.x, startingPos.y -2.5f, startingPos.z);
        float elapsedTime = 0;
        float duration = 0.3f;
        animator.SetTrigger("Smack");
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(camera.Shake(0.3f, 1f));

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
        playerFound = 0;
    }
}
