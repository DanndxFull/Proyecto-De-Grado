using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInteraction : MonoBehaviour
{
    [SerializeField] GameObject camera,camera2;
    [SerializeField] List<GameObject> objectsToggle;
    PlayerController player;
    Rigidbody rb;

    [SerializeField] List<Rigidbody> bodys;
    [SerializeField] MonoBehaviour test;

    public bool startedPuzle;

    private void Start()
    {
        player = PlayerController.instance;
        rb = GetComponent<Rigidbody>();
    }
    public void StartToInteractions()
    {
        if (startedPuzle)
            return;

        startedPuzle = true;
        camera.SetActive(true);
        camera2.SetActive(false);
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.transform.rotation = this.transform.rotation;
        player.transform.position = Vector3.back * 1.5f + Vector3.up;
        player.transform.SetParent(this.transform);
        player.canMove = false;
        rb.isKinematic = false;
        RigidBodyesKinematics(false);
        ObjectsActivate(true);
        test.enabled = true;
    }

    public void FinishInteract()
    {
        camera.SetActive(false);
        camera2.SetActive(true);
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.canMove = true;
        player.transform.SetParent(null);        
        rb.isKinematic = true;
        RigidBodyesKinematics(true);
        ObjectsActivate(false);
        test.enabled = false;
    }

    private void RigidBodyesKinematics(bool state)
    {
        foreach (Rigidbody r in bodys)
        {
            r.isKinematic = state;
        }
    }

    private void ObjectsActivate(bool state)
    {
        foreach(GameObject GO in objectsToggle)
        {
            GO.SetActive(state);
        }
    }
}
