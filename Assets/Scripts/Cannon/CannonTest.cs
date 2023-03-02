using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTest : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform pointToSpawn;
    [SerializeField] float force;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            projectile.SetActive(true);
            projectile.GetComponent<Rigidbody>().AddForce(Vector3.left* force, ForceMode.Impulse);
            Debug.Log("invoke");
        }
    }
}
