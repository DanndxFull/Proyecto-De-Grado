using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;
using System.Collections.Generic;

public class TestOfCalculate : MonoBehaviour
{
    [SerializeField] List<string> texts;
    [SerializeField] TMP_InputField inputFieldAnswer;
    [SerializeField] GameObject inputFieldAnswerObject,buttonEnterAnswer, buttonNextDialogue, dialogueControlls;
    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] PlayerController player;

    [SerializeField] float correctAnswer;
    float currentAnswer;

    [SerializeField] UnityEvent winEvent,loseEvent;
    [SerializeField] int index;
    [SerializeField] int indexOfAnswer;
    public bool active;

    public void StartDialogue()
    {
        if (active)
            return;

        index = 0;
        Debug.Log("Started");
        textBox.text = texts[index];
        player.canMove = false;
        dialogueControlls.SetActive(true);
        active = true;
        NewtonManager.newtonManager.SetCurrent(this);
    }

    public void NextDialogue()
    {
        index++;
        textBox.text = texts[index];
        if(index == indexOfAnswer)
        {
            buttonNextDialogue.SetActive(false);
            inputFieldAnswerObject.SetActive(true);
            buttonEnterAnswer.SetActive(true);
        }
    }

    public void EnterAnswer()
    {
        if (inputFieldAnswer.text == null || inputFieldAnswer.text == "")
            return;

        string answer = inputFieldAnswer.text;
        currentAnswer = Int32.Parse(answer);
        if(currentAnswer == correctAnswer)
        {
            player.canMove = true;
            winEvent.Invoke();
        }
        else
        {
            loseEvent.Invoke();
        }
    }
}