using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tears : MonoBehaviour
{
    public GameObject tearWarning;
    //public GameObject tearAsset;
    private float tearTrigger = 0;
    //private float warningDuration = 3;

    // Start is called before the first frame update
    void Start()
    {
        //triggerTears();
    }

    // Update is called once per frame
    void Update()
    {
        tearTrigger += Time.deltaTime;
        //warningDuration -= Time.deltaTime;
        float target = Random.Range(1f,7f);

        if (tearTrigger >= target)
        {
            triggerTears();
            tearTrigger = 0;
        }
    }

    void tearStart()
    {

    }

    void triggerTears()
    {
        // Find random coordinate pair
        float minX = -7f; //minimum X value
        float maxX = 7f; //maximum X value
        float minY = -1.47f; //minimum Y value
        float maxY = -4.49f; //maximum Y value

        Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        GameObject instance = Instantiate(tearWarning, spawnPosition, Quaternion.identity);
        tearTrigger = 0;
        //tearAttack(spawnPosition);

        /* if (warningDuration <= 0)
        {
            Destroy(instance);
            warningDuration = 3;
            spawnPosition = (Vector2.up * 3) + spawnPosition;
            GameObject tear = Instantiate(tearAsset, spawnPosition, Quaternion.identity);
            tearTrigger = 0;
            //Destroy(instance);
        } */
    }

/*     void tearAttack(Vector2 fallLocation)
    {
        warningDuration = 3;
        if (warningDuration <= 0)
        {
            fallLocation = (Vector2.up * 3) + fallLocation;
            GameObject tear = Instantiate(tearAsset, fallLocation, Quaternion.identity);
            tearTrigger = 0;
        }
    } */

}
