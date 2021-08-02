using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera; 

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchposition = Touchscreen.current.primaryTouch.position.ReadValue();
            Debug.Log(touchposition);

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchposition);

            Debug.Log(worldPosition);
        }
    }
}