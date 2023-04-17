using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float baseIntensity;
    public float intensityRange;
    public float intensityTimeMin;
    public float intensityTimeMax;
    public bool flickIntensity;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlickIntensity());
    }

    void Update()
    {
        flickIntensity = true;
    }

    // Update is called once per frame
    private IEnumerator FlickIntensity()
    {
        float t0 = Time.time;
        float t = t0;
        WaitUntil wait = new WaitUntil(() => Time.time > t0 + t);
        yield return new WaitForSeconds(Random.Range(0.01f, 0.5f));

        while (true)
        {
            if (flickIntensity)
            {
                t0 = Time.time;
                float r = Random.Range(baseIntensity - intensityRange, baseIntensity + intensityRange);
                GetComponent<Light>().intensity = r;
                t = Random.Range(intensityTimeMin, intensityTimeMax);
                yield return wait;
            }
            else yield return null;
        }
    }
}
