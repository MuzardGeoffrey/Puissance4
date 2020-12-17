using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
     }
}
