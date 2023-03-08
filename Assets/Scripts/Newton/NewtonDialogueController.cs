using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewtonDialogueController : MonoBehaviour
{
    public DialoguesNewton currentDialogue;
    [SerializeField] GameObject textPanel;
    [SerializeField] TextMeshProUGUI textNewton;

    public void SetDialogue(DialoguesNewton dialogues)
    {
        currentDialogue = dialogues;
    }

    public void ShowDialogue()
    {
        textPanel.SetActive(true);
        textNewton.text = currentDialogue.dialogues[0];
    }
}
