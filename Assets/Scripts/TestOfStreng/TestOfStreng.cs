using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOfStreng : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] StartInteraction start;
    [SerializeField] AnimationsController anim;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform playerPosition, playerPositionTarget;

    bool canPush;
    [SerializeField] float forcePush;

    private void OnEnable()
    {
        if (!player.strong)
        {
            ShortMessage.instanceMessage.ShowMessage("The player isn't strongh enough to push the object",3);
            start.StopInteraction();
            anim.PushingToggle(false);
        }
        else
        {
            canPush = true;
            anim.PushingToggle(true);
        }
    }

    private void Update()
    {
        if (canPush)
        {
            float input = Input.GetAxis("Vertical");
            if (input < 0)
                input = 0;

            if (input > 0)
            {                
                rb.AddForce(Vector3.forward*forcePush,ForceMode.Impulse);
                playerPosition.position = playerPositionTarget.position;
            }
        }
    }

}
