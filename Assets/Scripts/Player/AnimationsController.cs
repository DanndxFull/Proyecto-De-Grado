using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    Animator anim;
    float speed, timeBeenStay;
    [SerializeField] float timeToDance;
    bool isIDLEING;

    private void Start()
    {
        isIDLEING = false;
        timeBeenStay = 0;
        anim = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        timeBeenStay += Time.deltaTime;
        if (rb.velocity.magnitude > 0.1f && rb.velocity.y==0)
        {
            timeBeenStay = 0;
            anim.SetBool("IDLEOTHERS", false);
            speed = 1;
            isIDLEING = false;
        }
        else
        {
            speed = 0;
        }
        if (timeBeenStay > timeToDance)
        {
            if (!isIDLEING)
            {
                isIDLEING = true;
                int animation = Random.Range(1,3);
                anim.SetFloat("IDLEANIMATION", animation);
                anim.SetBool("IDLEOTHERS", true);
            }
        }
        anim.SetFloat("Moving",speed);
    }
}
