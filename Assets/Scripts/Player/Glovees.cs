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
            other.GetComponent<PlayerController>().UpdateForce(10);
            ShortMessage.instanceMessage.ShowMessage("You Feel Stronger", 2);
            this.gameObject.SetActive(false);
        }
    }
}
