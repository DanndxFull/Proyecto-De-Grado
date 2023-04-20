using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class SimpleMoveDoTween : MonoBehaviour
{
    [SerializeField] private float magnitudeOfMovement;
    [SerializeField] private UnityEvent eventOnFinish;

    public void MoveFrontX()
    {
        transform.DOMoveX(transform.position.x + magnitudeOfMovement,15).OnComplete(()=>eventOnFinish.Invoke());
    }

    public void MoveFrontY()
    {
        transform.DOMoveY(transform.position.y + magnitudeOfMovement, 15).OnComplete(() => eventOnFinish.Invoke());
    }

    public void MoveFrontZ()
    {
        transform.DOMoveZ(transform.position.z + magnitudeOfMovement, 15).OnComplete(() => eventOnFinish.Invoke());

    }
}
