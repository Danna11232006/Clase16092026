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
    PlayerInteraction playerInteraction;
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
        playerInteraction = GetComponent<PlayerInteraction>();
    }

    private void OnEnable()
    {
        interactInput.started += OnInteractPerformed;
    }

    private void OnDisable()
    {
        interactInput.started -= OnInteractPerformed;
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
        if(Inventory.Instance.hasPotion)
        {
            playerInteraction.DrinkPotion();
            Inventory.Instance.hasPotion = false;
            Debug.Log("Se tomó: " + Inventory.Instance.potion.potionName);
            Inventory.Instance.potion = null;
            HUDManager.Instance.ResetPotionName();
        }
        else 
        {
            Debug.Log("No hay poción");
        }
    }
}


