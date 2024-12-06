using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(WeaponController))]
public class WepPlayerController : MonoBehaviour
{
    private WeaponController weaponController;

    private WeaponPlayerDemoInput input;




    #region UnityFunctions
    private void Awake()
    {
        //Get references of required Components
        weaponController = GetComponent<WeaponController>();

        input = new WeaponPlayerDemoInput();

    }

    private void OnEnable()
    {
        SubscribeInputActions();
        input.Demo.Enable();


    }

    private void OnDisable()
    {
        UnsubscribeInputActions();
        input.Demo.Disable();
    }

    #endregion

    #region Custom Functions

    #region Input Subscriptions

    private void SubscribeInputActions()
    {

        input.Demo.UseLeft.performed += LeftWeaponPerformed;
        input.Demo.UseRight.performed += RightWeaponPerformed;

    }

    private void UnsubscribeInputActions()
    {
        input.Demo.UseLeft.performed -= LeftWeaponPerformed;
        input.Demo.UseRight.performed -= RightWeaponPerformed;
    }


    #endregion


    #region Weapon Input Actions

    private void LeftWeaponPerformed(InputAction.CallbackContext context)
    {

        //Tell the weaponController to use the left weapon
        weaponController.UseLeft();

    }

    private void RightWeaponPerformed(InputAction.CallbackContext context) 
    {

        //Tell the weaponController to use the right weapon
        weaponController.UseRight();

    } 



    #endregion





    #endregion


}
