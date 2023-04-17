using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalBossScream : MonoBehaviour
{
    [SerializeField]private GameObject screamPreFab;
    [SerializeField]private float attackSpread;
    [SerializeField]private float spreadShot;
    private enemyFollow enemyFollowScript;
    private GameObject Enemy;
    [SerializeField]private Animator animator;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.Find("FinalBoss");
        enemyFollowScript = Enemy.GetComponent<enemyFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Player");
    }

    void FireRoutine(Quaternion newRot)
    {
        Instantiate(screamPreFab).GetComponent<screamBehaviour>().SpawnBullet(transform.position, newRot);
    }

    public void Scream()
    {
        animator.SetTrigger("screamAttack");
        Vector2 targetPosition = Player.transform.position - transform.position;
        Vector2 dirTowardsTarget = (targetPosition - (Vector2)transform.position);
        transform.right = targetPosition.normalized;

        enemyFollowScript.canMove = false;
        StartCoroutine(CreateScreamInstances());
    }

    private IEnumerator CreateScreamInstances()
    {
        Quaternion newRot;
        for (int i = 0; i < spreadShot; i++)
        {
            float addedOffset = (i - (spreadShot / 2)) * attackSpread;

            newRot = Quaternion.Euler(transform.localEulerAngles.x,
                transform.localEulerAngles.y,
                transform.localEulerAngles.z + addedOffset);

            Instantiate(screamPreFab).GetComponent<screamBehaviour>().SpawnBullet(transform.position, newRot);
            yield return null;
        }

        yield return new WaitForSeconds(2);
        enemyFollowScript.canMove = true;
    }
}
