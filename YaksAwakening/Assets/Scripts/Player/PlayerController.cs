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

    private void Start()
    {
        GameState.Instance.OnGameResumed.AddListener(OnGameResumedCallback);
        GameState.Instance.OnGamePaused.AddListener(OnGamePausedCallback);
    }

    private void OnEnable()
    {
        SubscribeInputActions();

        SwitchActionMap("Player");

    }

    private void OnDisable()
    {
        UnSubscribeInputActions();

        SwitchActionMap();
    }

    private void OnDestroy()
    {
        GameState.Instance.OnGamePaused.RemoveListener(OnGamePausedCallback);
        GameState.Instance.OnGameResumed.RemoveListener(OnGameResumedCallback);
    }

    #endregion

    #region Custom Functions

    private void SubscribeInputActions()
    {

        inputActions.Player.Move.started += MoveAction;
        inputActions.Player.Move.performed += MoveAction;
        inputActions.Player.Move.canceled += MoveAction;

        inputActions.Player.OpenInventory.performed += InventoryAction;
        inputActions.Player.OpenMap.performed += MapAction;

        inputActions.UI.OpenMap.performed += MapAction;

        inputActions.UI.OpenInventory.performed += InventoryAction;

        

    }

    private void UnSubscribeInputActions()
    {

        inputActions.Player.Move.started -= MoveAction;
        inputActions.Player.Move.performed -= MoveAction;
        inputActions.Player.Move.canceled -= MoveAction;

        inputActions.Player.OpenInventory.performed -= InventoryAction;
        inputActions.Player.OpenMap.performed -= MapAction;

        inputActions.UI.OpenMap.performed -= MapAction;

        inputActions.UI.OpenInventory.performed -= InventoryAction;

    }

    #region Movement

    private void MoveAction(InputAction.CallbackContext context)
    {
        Debug.Log("Walk triggered");

        inputMovement = context.ReadValue<Vector2>();

        playerMovement.SetMovement(inputMovement);
    }

    #endregion

    #region Pause/Menus

    private void InventoryAction(InputAction.CallbackContext context)
    {
        GameManager.Instance.TogglePause();

    }

    private void MapAction(InputAction.CallbackContext context)
    {
        GameManager.Instance.TogglePause();

    }

    private void SwitchActionMap(string mapName = "")
    {
        inputActions.Player.Disable();
        inputActions.UI.Disable();

        switch (mapName)
        {

            case "Player":
                inputActions.Player.Enable();

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                break;

            case "UI":

                inputActions.UI.Enable();

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;

            default:

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;

        }


    }

    private void OnGamePausedCallback()
    {
        SwitchActionMap("UI");
    }

    private void OnGameResumedCallback()
    {
        SwitchActionMap("Player");
    }

    public void PauseMovement()
    {
        SwitchActionMap();
    }

    public void ResumeMovement()
    {
        SwitchActionMap("Player");
    }


    #endregion



    #endregion

}