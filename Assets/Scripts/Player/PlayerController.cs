using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Movement Variables")]
    //Input Fileds
    private PlayerInputAssets playerActionAsssets;
    private InputAction move;

    //Movement Fields
    private Rigidbody rb;
    [SerializeField] float movementForce;
    [SerializeField] float jumpForce;
    [SerializeField] float maxSpeed;
    [SerializeField] float gravityMultiplier;
    [SerializeField] float turnSmoothVelocity;
    [SerializeField] float turnSmoothTime = 0.1f;
    public bool canMove;

    private Vector3 forceDirection = Vector3.zero;

    public LayerMask Ground;

    [SerializeField] Camera playerCamera;


    [Header("Interact Variables")]

    [SerializeField] GameObject toInteracto;
    bool isInteracting;

    private void Awake()
    {
        instance = this;
        Cursor.lockState = CursorLockMode.Confined;
        rb = GetComponent<Rigidbody>();
        playerActionAsssets = new PlayerInputAssets();
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable()
    {
        playerActionAsssets.Player.Jump.started += DoJump;
        playerActionAsssets.Player.Interact.started += DoInteract;
        move = playerActionAsssets.Player.Move;
        playerActionAsssets.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionAsssets.Player.Jump.started -= DoJump;
        playerActionAsssets.Player.Interact.started -= DoInteract;
        playerActionAsssets.Player.Disable();
    }
    private void DoInteract(InputAction.CallbackContext obj)
    {
        if (isInteracting && canMove)
        {
            toInteracto.GetComponent<StartInteraction>().StartToInteractions();
        }
    }


    private void DoJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded() && canMove)
        {
            forceDirection += Vector3.up * jumpForce;
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + -Vector3.up, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 1.2f, Ground))
            return true;
        else
            return false;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
            forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

            rb.AddForce(forceDirection, ForceMode.Impulse);
            forceDirection = Vector3.zero;

            if (rb.velocity.y < 0f)
                rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime * gravityMultiplier;

            Vector3 horizontalVelocity = rb.velocity;
            horizontalVelocity.y = 0;
            if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
                rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

            LookAt();
        }
    }

    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            float targetAngle = MathF.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        else
            rb.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isInteracting=true;
            toInteracto = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable") && other.GetComponent<StartInteraction>().startedPuzle)
        {
            isInteracting=false;
            toInteracto = null;
        }
    }
}
