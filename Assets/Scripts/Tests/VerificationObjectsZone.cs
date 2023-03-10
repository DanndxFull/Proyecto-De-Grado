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
    [SerializeField] bool StartInteraction;
    [SerializeField] int score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            currentAmount++;
            if(currentAmount >= amountOfObjects)
            {
                Debug.Log(other.tag);
                Win();
            }
        }
    }

    public void Win()
    {
        ScoreManager.instanceScore.UpdateScore(score);
        winEvent.Invoke();
        if(StartInteraction)
            interactionController.FinishInteract();
    }
}
