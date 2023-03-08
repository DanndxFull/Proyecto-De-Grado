using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShortMessage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textField;
    [SerializeField] GameObject textFieldObject;
    public float timeToShow;

    public static ShortMessage instanceMessage;

    

    private void Awake()
    {
        instanceMessage = this;
    }

    public void ShowMessage(string message, float i)
    {
        textField.text = message;
        timeToShow = i;
        textFieldObject.SetActive(true);
        StartCoroutine(DisappearMessage());
    }

    IEnumerator DisappearMessage()
    {
        yield return new WaitForSeconds(timeToShow);
        textFieldObject.SetActive(false);
    }
}
