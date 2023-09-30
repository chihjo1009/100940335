using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleJump : MonoBehaviour
{
    private Rigidbody rb;
    private GameControls controls;

    public float jumpForce = 5f;
    private float currentRotationY = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new GameControls();


        controls.Player.Jump.performed += ctx => doJump();
        controls.Player.RotateLeft.performed += ctx => Rotate(-90f); 
        controls.Player.RotateRight.performed += ctx => Rotate(90f); 
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void doJump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log("Jump!!");
    }
    private void Rotate(float angle)
    {
        currentRotationY += angle;
        transform.eulerAngles = new Vector3(0, currentRotationY, 0);
        Debug.Log($"Rotated to {currentRotationY} degrees");
    }
}
