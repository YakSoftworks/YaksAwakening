using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Variables

    #region Movement
    private PlayerInputActions inputActions;

    private Vector2 inputMovement;

    [SerializeField] private PlayerMovement playerMovement;

    #endregion

    #endregion

    #region UnityFunctions

    private void Awake()
    {

        inputActions = new PlayerInputActions();

    }

    private void OnEnable()
    {
        SubscribeInputActions();

        inputActions.Player.Enable();

    }

    private void OnDisable()
    {
        UnSubscribeInputActions();

        inputActions.Player.Disable();
    }

    #endregion

    #region Custom Functions

    private void SubscribeInputActions()
    {

        inputActions.Player.Move.started += MoveAction;
        inputActions.Player.Move.performed += MoveAction;
        inputActions.Player.Move.canceled += MoveAction;

    }

    private void UnSubscribeInputActions()
    {

        inputActions.Player.Move.started -= MoveAction;
        inputActions.Player.Move.performed -= MoveAction;
        inputActions.Player.Move.canceled -= MoveAction;

    }

    #region Movement

    private void MoveAction(InputAction.CallbackContext context)
    {
        Debug.Log("Walk triggered");

        inputMovement = context.ReadValue<Vector2>();

        playerMovement.SetMovement(inputMovement);
    }

    #endregion

    #endregion





}