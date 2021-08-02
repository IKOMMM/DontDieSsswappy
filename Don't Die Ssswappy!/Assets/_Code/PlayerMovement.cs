using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;

    private Rigidbody rb;
    private Camera mainCamera;
    private Vector3 movementDirection;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        KeepPlayerOnScreen();
    }

    private void FixedUpdate()
    {
        PlayerForceMovement();
    }

    void ProcessInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchposition = Touchscreen.current.primaryTouch.position.ReadValue();

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchposition);

            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0f;
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    void PlayerForceMovement()
    {
        if (movementDirection == Vector3.zero) { return; }
        rb.AddForce(movementDirection * forceMagnitude * Time.deltaTime, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 ViewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if(ViewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if(ViewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }
        else if (ViewportPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if (ViewportPosition.x < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }

        transform.position = newPosition;
    }
}
