using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    #region Variables

    #region Movement
    [Header("Movement")]
    private PlayerInputActions inputActions;

    private Vector2 inputMovement;

    [SerializeField] private PlayerMovement playerMovement;

    #endregion

    public bool justMovedScenes;

    #region RoomChanges
    [Header("Room Changing")]

    [SerializeField] float cameraSpeed;
    [SerializeField] float playerSpeed;

    [Space(20)]

    [SerializeField] float horizontalCameraMoveDistance = 16f;
    [SerializeField] float verticalCameraMoveDistance = 12f;
    [SerializeField] float horizontalPlayerMoveDistance;
    [SerializeField] float verticalPlayerMoveDistance;

    [SerializeField] Transform cameraTransform;





    #endregion


    #endregion

    #region UnityFunctions

    private void Awake()
    {

        inputActions = new PlayerInputActions();
        justMovedScenes = false;

    }

    private void Start()
    {
        GameState.Instance.OnGameResumed.AddListener(OnGameResumedCallback);
        GameState.Instance.OnGamePaused.AddListener(OnGamePausedCallback);
    }

    private void OnEnable()
    {
        SubscribeInputActions();

        SwitchActionMap("UI");

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
        //Debug.Log("Walk triggered");

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


    public IEnumerator MoveCameraAndPlayerToNewLocation(Direction direction)
    {
        PauseMovement();
        justMovedScenes = true;

        Vector3 cameraTarget = cameraTransform.position;
        Vector3 playerTarget = transform.position;

        switch (direction)
        {
            case Direction.Up:
                 cameraTarget.y += verticalCameraMoveDistance;
                 playerTarget.y += verticalPlayerMoveDistance;
                break;

            case Direction.Right:
                cameraTarget.x += horizontalCameraMoveDistance;
                playerTarget.x += horizontalPlayerMoveDistance;
                break;

            case Direction.Down:
                cameraTarget.y -= verticalCameraMoveDistance;
                playerTarget.y -= verticalPlayerMoveDistance;
                break;

            case Direction.Left:
                cameraTarget.x -= horizontalCameraMoveDistance;
                playerTarget.x -= horizontalPlayerMoveDistance;
                break;
        }

        Debug.Log(playerTarget);
        Debug.Log(cameraTarget);


        while (cameraTransform.position != cameraTarget)
        {

            //Update player
            Vector3 location = transform.position;

            location = Vector3.MoveTowards(location, playerTarget, playerSpeed * Time.deltaTime);
            transform.position = location;

            //Update Camera

            Vector3 cameraLocation = cameraTransform.position;

            cameraLocation = Vector3.MoveTowards(cameraLocation, cameraTarget, cameraSpeed * Time.deltaTime);

            cameraTransform.position = cameraLocation;

            yield return null;
        }

        Debug.Log("Coroutine Finished");

        GetComponent<PlayerController>().ResumeMovement();

        GameManager.Instance.EnableCurrentRoom();

    }

}
