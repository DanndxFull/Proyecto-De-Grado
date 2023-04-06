using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleDirectionForce : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float force;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PushObjectFront()
    {
        rb.AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
    }

    public void PushObjectBack()
    {
        rb.AddRelativeForce(Vector3.back * force, ForceMode.Impulse);
    }
    public void PushObjectRight()
    {
        rb.AddRelativeForce(Vector3.right * force, ForceMode.Impulse);
    }
    public void PushObjectLeft()
    {
        rb.AddRelativeForce(Vector3.left * force, ForceMode.Impulse);
    }
}
