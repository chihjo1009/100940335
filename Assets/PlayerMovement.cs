using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    private Vector2 currentMovementInput;
    private Vector3 currentMoveDirection;
    private Rigidbody rb;

    private PlayerActions playerActions;  

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        playerActions = new PlayerActions();

        playerActions.PlayerMovement.Move.performed += ctx => currentMovementInput = ctx.ReadValue<Vector2>();
        playerActions.PlayerMovement.Move.canceled += ctx => currentMovementInput = Vector2.zero;

        playerActions.PlayerMovement.Jump.performed += ctx => Jump();
    }

    private void Update()
    {
        currentMoveDirection = new Vector3(currentMovementInput.x, 0, currentMovementInput.y).normalized;
        transform.Translate(currentMoveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }
}