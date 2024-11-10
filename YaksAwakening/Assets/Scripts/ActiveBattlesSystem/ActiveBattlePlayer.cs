using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActiveBattlePlayer : MonoBehaviour
{


    [SerializeField] PlayerBattleController controller;


    private ActiveBattleInput input;

    private void Awake()
    {
        input = new ActiveBattleInput();
    }



    private void OnEnable()
    {
        SubscibeInputActions();

        input.ActiveBattle.Enable();
    }

    private void OnDisable()
    {
        input.ActiveBattle.Disable();
    }

    private void OnDestroy()
    {
        UnSubscribeActions();
    }

    private void SubscibeInputActions()
    {
        input.ActiveBattle.One.performed += (InputAction.CallbackContext context) => ActionPerformed(0);
        input.ActiveBattle.Two.performed += (InputAction.CallbackContext context) => ActionPerformed(1);
        input.ActiveBattle.Three.performed += (InputAction.CallbackContext context) => ActionPerformed(2);
        input.ActiveBattle.Four.performed += (InputAction.CallbackContext context) => ActionPerformed(3);
        input.ActiveBattle.Five.performed += (InputAction.CallbackContext context) => ActionPerformed(4);
        input.ActiveBattle.Six.performed += (InputAction.CallbackContext context) => ActionPerformed(5);
        input.ActiveBattle.Seven.performed += (InputAction.CallbackContext context) => ActionPerformed(6);
        input.ActiveBattle.Eight.performed += (InputAction.CallbackContext context) => ActionPerformed(7);
        input.ActiveBattle.Nine.performed += (InputAction.CallbackContext context) => ActionPerformed(8);
        input.ActiveBattle.Zero.performed += (InputAction.CallbackContext context) => ActionPerformed(9);
        input.ActiveBattle.ActionL.performed += (InputAction.CallbackContext context) => ActionPerformed(10);
        input.ActiveBattle.ActionR.performed += (InputAction.CallbackContext context) => ActionPerformed(11);

    }

    private void UnSubscribeActions()
    {
        input.ActiveBattle.One.performed -= (InputAction.CallbackContext context) => ActionPerformed(0);
        input.ActiveBattle.Two.performed -= (InputAction.CallbackContext context) => ActionPerformed(1);
        input.ActiveBattle.Three.performed -= (InputAction.CallbackContext context) => ActionPerformed(2);
        input.ActiveBattle.Four.performed -= (InputAction.CallbackContext context) => ActionPerformed(3);
        input.ActiveBattle.Five.performed -= (InputAction.CallbackContext context) => ActionPerformed(4);
        input.ActiveBattle.Six.performed -= (InputAction.CallbackContext context) => ActionPerformed(5);
        input.ActiveBattle.Seven.performed -= (InputAction.CallbackContext context) => ActionPerformed(6);
        input.ActiveBattle.Eight.performed -= (InputAction.CallbackContext context) => ActionPerformed(7);
        input.ActiveBattle.Nine.performed -= (InputAction.CallbackContext context) => ActionPerformed(8);
        input.ActiveBattle.Zero.performed -= (InputAction.CallbackContext context) => ActionPerformed(9);
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
