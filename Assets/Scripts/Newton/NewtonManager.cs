using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonManager : MonoBehaviour
{
    List<TestOfCalculate> newtons;
    TestOfCalculate currentNewton;

    public static NewtonManager newtonManager;

    // Start is called before the first frame update
    void Start()
    {
        newtonManager = this;
        newtons = new List<TestOfCalculate>();
        foreach(GameObject n in GameObject.FindGameObjectsWithTag("Newton"))
        {
            newtons.Add(n.GetComponent<TestOfCalculate>());
        }
    }

    public void SetCurrent(TestOfCalculate n)
    {
        currentNewton = n;        
    }

    public void NextDialogueNewton()
    {
        currentNewton.NextDialogue();
    }

    public void EnterAnswerNewton()
    {
        currentNewton.EnterAnswer();
    }
}
