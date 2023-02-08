using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestOfPushToObjects : MonoBehaviour
{
    Rigidbody rb;
    PushObjecstAsset inputActions;

    [SerializeField] float forceLeft, forceRight;
    [SerializeField] Rigidbody push1, push2;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new PushObjecstAsset();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DoPushLeft();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            DoPushRight();
        }
    }

    private void DoPushLeft()
    {
        Debug.Log("Push1");
        push1.AddForce(Vector3.forward*(forceLeft/push1.mass), ForceMode.Impulse);
    }
    private void DoPushRight()
    {        
        Debug.Log("Push2");
        push2.AddForce(Vector3.forward * (forceRight / push2.mass), ForceMode.Impulse);
    }
}
