using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextDialogue : MonoBehaviour
{
    [SerializeField] List<string> texts;
    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] TMP_InputField fieldOfAnswer;
    int index;

    [SerializeField] GameObject optionA, optionB, textBoxAnswer,nextButton, enterAnswerButton, fieldAnswer;
    string answer;

    [SerializeField] VerificationZone verificationZone;
    private void Start()
    {
        index = 0;
    }

    public void NextText()
    {
        if (index == texts.Count)
        {
            textBoxAnswer.SetActive(true);
            enterAnswerButton.SetActive(true);
            nextButton.SetActive(false);
        }
        else
        {
            textBox.text = texts[index];
            index++;
        }
    }

    public void SetTextIndex(int i)
    {
        if (i > texts.Count)
            return;
        textBox.text = texts[i];
    }

    public void EnterAnswer()
    {
        answer = fieldOfAnswer.text;
        verificationZone.SetStudentAnswer2(Int32.Parse(answer));
        textBox.text = "y ahora dime, cual carro crees que llegue primero?";
        enterAnswerButton.SetActive(false);
        fieldAnswer.SetActive(false);
        optionA.SetActive(true);
        optionB.SetActive(true);
    }

}
