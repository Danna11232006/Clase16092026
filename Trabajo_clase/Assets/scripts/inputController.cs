using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
   public static InputController Instance;

    InputAction moveInput;
    InputAction interactInput;

    [HideInInspector] public Vector2 moveVector;

    void Awake(){

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        moveInput = InputSystem.actions.FindAction("Move");
        interactInput = InputSystem.actions.FindAction("Interact");
    }

    private void OnEnable()
    {
        interactInput.performed += OnInteractPerformed;
    }

    private void OnDisable()
    {
        interactInput.performed -= OnInteractPerformed;
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        moveVector = moveInput.ReadValue<Vector2>();
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
    }
}


