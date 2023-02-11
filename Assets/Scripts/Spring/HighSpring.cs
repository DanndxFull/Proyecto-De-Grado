using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighSpring : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject otherSpring;
    [SerializeField] float forceSpring;
    bool isPressed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {       
        if(other.gameObject == otherSpring && isPressed)
        {
            rb.AddForce(Vector3.up * forceSpring, ForceMode.Impulse);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            isPressed = true;
    }


    private void OnCollisionExit(Collision collision)
    {
            isPressed = false;
            rb.velocity = Vector3.zero;
    }
}
