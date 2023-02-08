using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInteraction : MonoBehaviour
{
    [SerializeField] GameObject camera;
    PlayerController player;
    Rigidbody rb;

    [SerializeField] Rigidbody push1, push2;
    [SerializeField] TestOfPushToObjects test;

    private void Start()
    {
        player = PlayerController.instance;
        rb = GetComponent<Rigidbody>();
    }
    public void StartToInteractions()
    {
        camera.SetActive(true);
        Camera.main.gameObject.SetActive(false);
        //player.transform.position = new Vector3(this.transform.position.x,1, this.transform.position.z);
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
}
