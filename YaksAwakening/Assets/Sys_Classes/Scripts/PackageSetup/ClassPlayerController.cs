using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClassPlayerController : MonoBehaviour
{

    private ClassSystemInput inputActions;

    #region UnityFunctions
    private void Awake()
    {
        inputActions = new ClassSystemInput();
    }

    private void OnEnable()
    {
        inputActions.DEBUG.Enable();
        SubscribeInputActions();
    }

    private void OnDisable()
    {
        inputActions.DEBUG.Disable();
        UnsubscribeInputActions();
    }
    #endregion

    #region Inputs
    private void SubscribeInputActions()
    {
        inputActions.DEBUG.RightChangeClass.performed += ChangeClassRight;
        inputActions.DEBUG.LeftChangeClass.performed += ChangeClassLeft;

        inputActions.DEBUG.UseAbility1.performed += UseAbility1Performed;
        inputActions.DEBUG.UseAbility2.performed += UseAbility2Performed;
        inputActions.DEBUG.UseAbility3.performed += UseAbility3Performed;

    }

    private void UnsubscribeInputActions() 
    {

        inputActions.DEBUG.RightChangeClass.performed -= ChangeClassRight;
        inputActions.DEBUG.LeftChangeClass.performed -= ChangeClassLeft;

        inputActions.DEBUG.UseAbility1.performed -= UseAbility1Performed;
        inputActions.DEBUG.UseAbility2.performed -= UseAbility2Performed;
        inputActions.DEBUG.UseAbility3.performed -= UseAbility3Performed;

    }

    #endregion

    #region InputActions

    #region ChangeClassInput

    private void ChangeClassRight(InputAction.CallbackContext context)
    {
        PlayerState.Instance.ChangeClass(1);
    }

    private void ChangeClassLeft(InputAction.CallbackContext context)
    {
        PlayerState.Instance.ChangeClass(-1);
    }

    #endregion

    #region UseAbilityActions

    private void UseAbility1Performed(InputAction.CallbackContext context)
    {
        PlayerState.Instance.UseAbility(0);
    }

    private void UseAbility2Performed(InputAction.CallbackContext context)
    {
        PlayerState.Instance.UseAbility(1);
    }

    private void UseAbility3Performed(InputAction.CallbackContext context)
    {
        PlayerState.Instance.UseAbility(2);
    }


    #endregion

    #endregion



}
