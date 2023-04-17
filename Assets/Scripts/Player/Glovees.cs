using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glovees : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().strong = true;
            this.gameObject.SetActive(false);
        }
    }
}
