using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearsFalling : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float duration = 1f; // duration of the slide in seconds
    private float elapsedTime = 0.0f; // elapsed time since the start of the slide
    public Animator animator;
    [SerializeField]public int damage;

    void Start()
    {
        GameObject player = GameObject.Find("Player");

        // record the initial position of the object
        initialPosition = transform.position;

        // calculate the target position (2 units down from the initial position)
        targetPosition = initialPosition - new Vector3(0, 3,0);
    }

    void Update()
    {
        // increment the elapsed time
        elapsedTime += Time.deltaTime;

        // calculate the interpolation factor based on the elapsed time and the duration
        float t = Mathf.Clamp01(elapsedTime / duration);

        // interpolate between the initial and target positions using the interpolation factor
        transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

        if (transform.position == targetPosition)
        {
            tearCollide();
        }
    }

    void tearCollide()
    {
        animator.SetTrigger("Splash");
        CapsuleCollider2D capsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
        capsuleCollider.enabled = true;
        StartCoroutine(splashDuration());
    }

    IEnumerator splashDuration()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Col");
        if(other.tag == "Player" && SwitchBody.inGhost == true)
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

}
