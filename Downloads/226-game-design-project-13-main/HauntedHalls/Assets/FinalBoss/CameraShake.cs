using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        //Debug.Log("Shake");
        Vector3 originalPos = transform.localPosition;

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.5f,0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f,0.5f) * magnitude;

            transform.localPosition = new Vector3(xOffset, yOffset,originalPos.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

}
