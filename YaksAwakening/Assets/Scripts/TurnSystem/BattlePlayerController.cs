using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Temporary Class to 

public class BattlePlayerController : MonoBehaviour
{

    private PlayerInputActions inputActions;

    [SerializeField] BattleController battleSystem;


    private void Awake()
    {
        inputActions = new PlayerInputActions();


    }

    private void Start()
    {
        SubscribeInputActions();

        inputActions.Battle.Enable();
    }

    private void SubscribeInputActions()
    {
        inputActions.Battle.SwitchLeft.performed += OnSwitchLeftPerformed;
        inputActions.Battle.SwitchRight.performed += OnSwitchRightPerformed;
    }

    private void UnSubscribeInputActions()
    {
        inputActions.Battle.SwitchLeft.performed -= OnSwitchLeftPerformed;
        inputActions.Battle.SwitchRight.performed -= OnSwitchRightPerformed;
    }

    private void OnDestroy()
    {
        UnSubscribeInputActions();
        inputActions.Battle.Disable();
    }


    //When we hit left/right bracket, change our current target forward or backward
    private void OnSwitchRightPerformed(InputAction.CallbackContext context)
    {
        battleSystem.turnManager.currentPlayer.IncrementCurrentTarget(1);
    }

    private void OnSwitchLeftPerformed(InputAction.CallbackContext context)
    {
        battleSystem.turnManager.currentPlayer.IncrementCurrentTarget(-1);
    }



}
