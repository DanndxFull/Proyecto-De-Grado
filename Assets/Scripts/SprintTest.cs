using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintTest : MonoBehaviour
{
    [SerializeField] Rigidbody rbParent;
    [SerializeField] Transform trParent;
    bool empty = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable"))
        {
            empty = false;
            other.transform.position = trParent.position;
            other.transform.parent = trParent;
            other.GetComponent<SpringJoint>().connectedBody = rbParent;
        }
    }
}
