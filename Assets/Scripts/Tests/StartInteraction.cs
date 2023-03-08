using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInteraction : MonoBehaviour
{
    [SerializeField] GameObject camera,camera2;
    [SerializeField] List<GameObject> objectsToggle;
    PlayerController player;

    [SerializeField] List<Rigidbody> bodys;
    [SerializeField] MonoBehaviour test;

    public bool startedPuzle;
    public bool ToggleRigidBodys = true, ToggleObjects = true;

    public Transform position, parent;

    private void Start()
    {
        player = PlayerController.instance;
    }
    public void StartToInteractions()
    {
        if (startedPuzle)
            return;

        startedPuzle = true;
        camera.SetActive(true);
        camera2.SetActive(false);
        //player.GetComponent<Rigidbody>().isKinematic = true;
        player.transform.parent = parent.transform; 
        player.transform.position = position.position;
        player.transform.rotation = position.rotation;
        player.canMove = false;
        if(ToggleRigidBodys)
            RigidBodyesKinematics(false);
        if(ToggleObjects)
            ObjectsActivate(true);
        test.enabled = true;
    }

    public void StopInteraction()
    {
        startedPuzle = false;
        camera.SetActive(false);
        camera2.SetActive(true);
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.canMove = true;
        player.transform.SetParent(null);
        if (ToggleRigidBodys)
            RigidBodyesKinematics(true);
        if (ToggleObjects)
            ObjectsActivate(false);
        test.enabled = false;
    }

    public void FinishInteract()
    {
        camera.SetActive(false);
        camera2.SetActive(true);
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.canMove = true;
        player.transform.SetParent(null);
        if(ToggleRigidBodys)
            RigidBodyesKinematics(true);
        if(ToggleObjects)
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
