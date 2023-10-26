using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private Vector2 movementInput;
    private bool shootTriggered;
    private PlayerControls controls;

    private AmmoManager ammoManager; //參考AmmoManager以檢查和消耗子彈

    private void Awake()
    {
        controls = new PlayerControls();

        controls.PlayerActions.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        controls.PlayerActions.Move.canceled += ctx => movementInput = Vector2.zero;

        controls.PlayerActions.Shoot.performed += ctx => shootTriggered = true;

        ammoManager = GetComponent<AmmoManager>(); // 從當前物件上獲取AmmoManager腳本的參考
    }

    private void OnEnable()
    {
        controls.PlayerActions.Enable();
    }

    private void OnDisable()
    {
        controls.PlayerActions.Disable();
    }

    private void Update()
    {
        Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (shootTriggered)
        {
            Shoot();
            shootTriggered = false;
        }
    }

    void Shoot()
    {
        if(ammoManager.TryShoot()) //檢查是否有子彈可以射擊
        {
            Debug.Log("Shooting!");
            // 在這裡添加你的射擊邏輯或特效
        }
        else
        {
            Debug.Log("No Ammo!");
        }
    }
}
