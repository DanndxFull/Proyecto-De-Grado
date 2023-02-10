using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestOfPushToObjects : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float forceLeft, forceRight, timeToPush;
    float currentTimeToPush1, currentTimeToPush2;
    [SerializeField] Rigidbody push1, push2;
    // Start is called before the first frame update
    void Awake()
    {
        currentTimeToPush1 = 0;
        currentTimeToPush2 = 0;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        currentTimeToPush1 += Time.deltaTime;
        currentTimeToPush2 += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q) && currentTimeToPush1>=timeToPush)
        {
            currentTimeToPush1 = 0;
            DoPushLeft();
        }
        if (Input.GetKeyDown(KeyCode.E) && currentTimeToPush2 >= timeToPush)
        {
            currentTimeToPush2 = 0;
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
