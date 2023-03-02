using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bascule : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textValue;
    float currentlyWeight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable"))
        {
            currentlyWeight += other.GetComponent<Weight>().weight;
            textValue.text = ""+ currentlyWeight;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabable"))
        {
            currentlyWeight -= other.GetComponent<Weight>().weight;
            textValue.text = ""+ currentlyWeight;            
        }        
    }
}
