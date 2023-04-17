using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    //private Vector3 offset;
    public bool isPanning = true;
    //private float panDuration = 3f;
    //private bool panBack = false;
    //public float maxDistance = 10f;
    private Vector3 initialposition;
    private Vector3 targetposition;

    private void Start()
    {
        initialposition = transform.position;
        targetposition = target.position;
        //targetposition = new Vector3(45, 0, 0);
        StartCoroutine(Panning());
            //transform.position - target.position;
    }

    private void Update()
    {
        if (transform.position == targetposition)
        {
            //StartCoroutine(PanBack());
        }
        /*if (isPanning)
        {
            Vector3 targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
            StartCoroutine(WaitForPan());
        }*/
        // Limit camera position to stay within maxDistance from target
        //transform.position = target.position + Vector3.ClampMagnitude(transform.position - target.position, maxDistance);
    }

/*    public void PanToTarget()
    {
        isPanning = true;
        panBack = false;
    }

    public void PanBack()
    {
        isPanning = true;
        panBack = true;
    }

    private IEnumerator WaitForPan()
    {
        yield return new WaitForSeconds(panDuration);
        isPanning = false;
    }*/

    private IEnumerator Panning()
    {
        isPanning = true;
        yield return new WaitForSeconds(1);
        float elapsedTime = 0;
        float duration = 3f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(initialposition, targetposition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(PanBack());
    }

    private IEnumerator PanBack()
    {
        yield return new WaitForSeconds(1);
        float elapsedTime = 0;
        float duration = 2f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(targetposition, initialposition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        isPanning = false;
    }
}
