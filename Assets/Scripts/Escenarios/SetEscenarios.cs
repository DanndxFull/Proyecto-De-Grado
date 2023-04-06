using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEscenarios : MonoBehaviour
{
    Escenario escenario;
    [SerializeField] List<GameObject> puzzles;
    [SerializeField] List<Transform> positionsPuzzles;

    private void Awake()
    {
        escenario = CurrentEscenario.instanceEscenario.escenario;
        int index = 0;
        foreach (int i in escenario.escenarios)
        {
            puzzles[i].transform.position = positionsPuzzles[index].position;
            puzzles[i].SetActive(true);
            index++;
        }
    }
}
