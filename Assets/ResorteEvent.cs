using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResorteEvent : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float force;
    [SerializeField] private Animator anim;

    public void StartAnimation()
    {
        anim.SetTrigger("Rebotar");
    }
    public void PushObject()
    {
        rb.isKinematic = false;
        rb.AddRelativeForce(Vector3.forward * force, ForceMode.Impulse);
    }
}
