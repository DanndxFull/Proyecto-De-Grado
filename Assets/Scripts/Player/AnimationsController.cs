using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    Animator anim;
    float speed, timeBeenStay;
    [SerializeField] float timeToDance;
    bool isIDLEING, isPushing;
    [SerializeField] PlayerController player;

    private void Start()
    {
        isIDLEING = false;
        timeBeenStay = 0;
        anim = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (player.canMove)
        {
            timeBeenStay += Time.deltaTime;
            anim.SetFloat("VelocidadY", rb.velocity.y);
            if (rb.velocity.magnitude > 0.1f && player.IsGrounded())
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
                    int animation = Random.Range(1, 3);
                    anim.SetFloat("IDLEANIMATION", animation);
                    anim.SetBool("IDLEOTHERS", true);
                }
            }
            anim.SetFloat("Moving", speed);
        }     
        else if (isPushing)
        {
            float input = Input.GetAxis("Vertical");
            if (input < 0)
                input = 0;

            if (input >= 1)
                input = 1;
            anim.SetFloat("Push", input);
        }
    }

    public void PushingToggle(bool state)
    {
        isPushing = state;
        anim.SetBool("Pushing", state);
    }
}
