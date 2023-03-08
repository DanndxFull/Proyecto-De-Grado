using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VerificationObjectsZone : MonoBehaviour
{
    [SerializeField] int amountOfObjects;
    [SerializeField] string tag;
    [SerializeField] StartInteraction interactionController;

    int currentAmount = 0;

    [SerializeField] UnityEvent winEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            currentAmount++;
            if(currentAmount == amountOfObjects)
            {
                Win();
            }
        }
    }

    public void Win()
    {
        ScoreManager.instanceScore.UpdateScore(4);
        interactionController.FinishInteract();
        winEvent.Invoke();
    }
}
