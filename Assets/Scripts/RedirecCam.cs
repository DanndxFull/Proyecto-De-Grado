using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedirecCam : MonoBehaviour
{
    [SerializeField] Transform pointToRedirect;

    public void Redirect()
    {
        transform.position = pointToRedirect.position;
    }
}
