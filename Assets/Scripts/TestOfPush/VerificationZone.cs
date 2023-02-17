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
    public int studentAnswer2, correctAnswer2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            amount++;
            if (amount >= 2)
            {
                test.puzzleFinished = true;
                interactionController.FinishInteract();
                if (correctAnswer == studentAnswer && correctAnswer2 == studentAnswer2)
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
    public void SetStudentAnswer2(int answer)
    {
        studentAnswer2 = answer;
    }
}
