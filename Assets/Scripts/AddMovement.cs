using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AddMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 100f;

    public DefaultInputActions defaultInputActions;
    void FixedUpdate()
    {
        Vector2 inputedButtons = defaultInputActions.Player.Move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(inputedButtons.x, 0, inputedButtons.y) * forwardForce * Time.deltaTime;
        Time.timeScale = 1;
        rb.AddForce(movement, ForceMode.VelocityChange);
    }

    private void Awake()
    {
        defaultInputActions = new DefaultInputActions();
    }

    private void OnEnable()
    {
        defaultInputActions.Enable();
    }

    private void OnDisable()
    {
        defaultInputActions.Disable();
    }
}