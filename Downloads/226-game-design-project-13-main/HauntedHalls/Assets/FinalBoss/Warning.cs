using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    private float warningDuration;
    public GameObject tearAsset;

    // Start is called before the first frame update
    void Start()
    {
        warningDuration = 3;
        StartCoroutine(spawnTear());
    }

    // Update is called once per frame
    void Update()
    {
        warningDuration -= Time.deltaTime;
        //Debug.Log(warningDuration);

        if (warningDuration <= 0)
        {
            //Debug.Log("here");
            //Vector3 spawnPosition = (Vector3.up * 3) + this.transform.position;
            //GameObject tear = Instantiate(tearAsset, spawnPosition, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    IEnumerator spawnTear()
    {
        yield return new WaitForSeconds(1.5f);
        Vector3 spawnPosition = (Vector3.up * 3) + this.transform.position;
        GameObject tear = Instantiate(tearAsset, spawnPosition, Quaternion.identity);
    }
}
