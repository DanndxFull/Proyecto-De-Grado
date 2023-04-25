using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SimpleRotateDoTween : MonoBehaviour
{
    [SerializeField] private Vector3 endValue;
    [SerializeField] private float time;

    public void RotateObject()
    {
        transform.DORotate(endValue,time);
    }
}
