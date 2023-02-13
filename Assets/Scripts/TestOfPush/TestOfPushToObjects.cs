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
    public bool puzzleFinished;
    // Start is called before the first frame update
    void Awake()
    {
        currentTimeToPush1 = 0;
        currentTimeToPush2 = 0;
        rb = GetComponent<Rigidbody>();
    }

    public void StartTest()
    {
        StartCoroutine(StartMoving());
    }

    IEnumerator StartMoving()
    {
        while (!puzzleFinished)
        {
            currentTimeToPush1 += Time.deltaTime;
            currentTimeToPush2 += Time.deltaTime;
            DoPushLeft();
            DoPushRight();        
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void DoPushLeft()
    {
        push1.AddForce(Vector3.forward*(forceLeft/push1.mass), ForceMode.Impulse);
        currentTimeToPush1 = 0;
    }
    private void DoPushRight()
    {        
        push2.AddForce(Vector3.forward * (forceRight / push2.mass), ForceMode.Impulse);
        currentTimeToPush2 = 0;
    }
}
