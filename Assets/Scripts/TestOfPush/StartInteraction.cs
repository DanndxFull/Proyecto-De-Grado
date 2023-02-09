using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInteraction : MonoBehaviour
{
    [SerializeField] GameObject camera,camera2;
    PlayerController player;
    Rigidbody rb;

    [SerializeField] Rigidbody push1, push2;
    [SerializeField] TestOfPushToObjects test;

    public bool startedPuzle;

    private void Start()
    {
        player = PlayerController.instance;
        rb = GetComponent<Rigidbody>();
    }
    public void StartToInteractions()
    {
        startedPuzle = true;
        camera.SetActive(true);
        camera2.SetActive(false);
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.transform.rotation = this.transform.rotation;
        player.transform.position = Vector3.back * 1.5f + Vector3.up;
        player.transform.SetParent(this.transform);
        player.canMove = false;
        rb.isKinematic = false;
        push1.isKinematic = false;
        push2.isKinematic = false;
        test.enabled = true;
    }

    public void FinishInteract()
    {
        camera.SetActive(false);
        camera2.SetActive(true);
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.canMove = true;
        player.transform.SetParent(null);        
        rb.isKinematic = false;
        push1.isKinematic = false;
        push2.isKinematic = false;
        test.enabled = false;
    }
}
