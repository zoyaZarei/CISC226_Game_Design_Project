// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PossessObject : MonoBehaviour
// {
//     public float pushForce = 1;

//     private void OnControllerColliderHit(ControllerColliderHit hit)
//     {
//         Rigidbody _rigg = hit.collider.attachedRigidbody;
//         Vector2 forceDirection;

//         if (_rigg != null)
//         {
//             forceDirection = hit.gameObject.transform.position - transform.position;
//             forceDirection.y = 0;
//             forceDirection.Normalize();
//             _rigg.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
//         }

//         _rigg.AddForceAtPosition(forceDirection * pushForce, transform.position, ForceMode.Impulse);
//     }
// }
