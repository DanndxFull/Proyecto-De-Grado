using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VerificationZone : MonoBehaviour
{
    [SerializeField] UnityEvent winEvent,loseEvent;

    int amount;
    [SerializeField] StartInteraction interactionController;
    [SerializeField] TestOfPushToObjects test;

    public int studentAnswer, correctAnswer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            amount++;
            if (amount >= 2)
            {
                test.puzzleFinished = true;
                interactionController.FinishInteract();
                if (correctAnswer == studentAnswer)
                {
                    winEvent.Invoke();
                }
                else
                {
                    loseEvent.Invoke();
                }
            }
        }
    }

    public void SetStudentAnswer(int answer)
    {
        studentAnswer = answer;
    }
}
