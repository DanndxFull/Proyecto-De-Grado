using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificationZone : MonoBehaviour
{
    int amount;
    [SerializeField] StartInteraction interactionController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            amount++;
            if (amount >= 2)
            {
                interactionController.FinishInteract();
            }
        }
    }
}
