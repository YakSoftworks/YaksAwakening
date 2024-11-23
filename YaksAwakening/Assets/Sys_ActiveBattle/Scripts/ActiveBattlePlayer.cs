using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActiveBattlePlayer : MonoBehaviour
{


    [SerializeField] PlayerBattleController controller;
    [SerializeField] private PlayerStats stats;

    [SerializeField] private BattlePlayerController currentTarget;



    public BattlePlayerController GetCurrentTarget()
    {
        return currentTarget;
    }


    private ActiveBattleInput input;

    private void Awake()
    {
        input = new ActiveBattleInput();
    }



    private void OnEnable()
    {
        SubscibeInputActions();

        input.AssignedActions.Enable();
    }

    private void OnDisable()
    {
        input.AssignedActions.Disable();
    }

    private void OnDestroy()
    {
        UnSubscribeActions();
    }

    private void SubscibeInputActions()
    {
        input.AssignedActions.One.performed += (InputAction.CallbackContext context) => ActionPerformed(0);
        input.AssignedActions.Two.performed += (InputAction.CallbackContext context) => ActionPerformed(1);
        input.AssignedActions.Three.performed += (InputAction.CallbackContext context) => ActionPerformed(2);
        input.AssignedActions.Four.performed += (InputAction.CallbackContext context) => ActionPerformed(3);
        input.AssignedActions.Five.performed += (InputAction.CallbackContext context) => ActionPerformed(4);
        input.AssignedActions.Six.performed += (InputAction.CallbackContext context) => ActionPerformed(5);
        input.AssignedActions.Seven.performed += (InputAction.CallbackContext context) => ActionPerformed(6);
        input.AssignedActions.Eight.performed += (InputAction.CallbackContext context) => ActionPerformed(7);
        input.AssignedActions.Nine.performed += (InputAction.CallbackContext context) => ActionPerformed(8);
        input.AssignedActions.Zero.performed += (InputAction.CallbackContext context) => ActionPerformed(9);
        input.ActiveBattle.ActionL.performed += (InputAction.CallbackContext context) => ActionPerformed(10);
        input.ActiveBattle.ActionR.performed += (InputAction.CallbackContext context) => ActionPerformed(11);

    }

    private void UnSubscribeActions()
    {
        input.AssignedActions.One.performed -= (InputAction.CallbackContext context) => ActionPerformed(0);
        input.AssignedActions.Two.performed -= (InputAction.CallbackContext context) => ActionPerformed(1);
        input.AssignedActions.Three.performed -= (InputAction.CallbackContext context) => ActionPerformed(2);
        input.AssignedActions.Four.performed -= (InputAction.CallbackContext context) => ActionPerformed(3);
        input.AssignedActions.Five.performed -= (InputAction.CallbackContext context) => ActionPerformed(4);
        input.AssignedActions.Six.performed -= (InputAction.CallbackContext context) => ActionPerformed(5);
        input.AssignedActions.Seven.performed -= (InputAction.CallbackContext context) => ActionPerformed(6);
        input.AssignedActions.Eight.performed -= (InputAction.CallbackContext context) => ActionPerformed(7);
        input.AssignedActions.Nine.performed -= (InputAction.CallbackContext context) => ActionPerformed(8);
        input.AssignedActions.Zero.performed -= (InputAction.CallbackContext context) => ActionPerformed(9);
        input.ActiveBattle.ActionL.performed -= (InputAction.CallbackContext context) => ActionPerformed(10);
        input.ActiveBattle.ActionR.performed -= (InputAction.CallbackContext context) => ActionPerformed(11);
    }



    private void Update()
    {
        controller.UpdateBattleController(Time.deltaTime);
    }


    private void ActionPerformed(int actionIndex)
    {
        controller.TriggerAction(actionIndex);
    }


}
