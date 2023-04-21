using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class SimpleMoveDoTween : MonoBehaviour
{
    [SerializeField] private float magnitudeOfMovement;
    [SerializeField] private int time = 15;
    [SerializeField] private UnityEvent eventOnFinish;

    public void MoveFrontX()
    {
        transform.DOMoveX(transform.position.x + magnitudeOfMovement, time).OnComplete(()=>eventOnFinish.Invoke());
    }

    public void MoveFrontY()
    {
        transform.DOMoveY(transform.position.y + magnitudeOfMovement, time).OnComplete(() => eventOnFinish.Invoke());
    }

    public void MoveFrontZ()
    {
        transform.DOMoveZ(transform.position.z + magnitudeOfMovement, time).OnComplete(() => eventOnFinish.Invoke());

    }
}
