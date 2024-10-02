using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class A1PlayerController : MonoBehaviour
{
    public Vector2 moveInputValue;
    public int rotateInputValue;
    public float moveForce;
    public float rotateForce;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(moveInputValue * moveForce * Time.deltaTime);
        rb.AddTorque(rotateForce * rotateInputValue * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        moveInputValue = value.ReadValue<Vector2>();
    }

    public void OnRotate(InputAction.CallbackContext value)
    {
        string key = value.control.name;
        if (key == "q")
            rotateInputValue = 1;
        else if (key == "e")
            rotateInputValue = -1;
        if (value.canceled)
            rotateInputValue = 0;
    }
}
