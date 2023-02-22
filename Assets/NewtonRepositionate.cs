using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonRepositionate : MonoBehaviour
{
    [SerializeField] List<Transform> pointsToMove;
    int index;

    private void Start()
    {
        index = 0;
    }

    public void NextPosition(int i)
    {
        transform.position = pointsToMove[i].position;
    }

}
