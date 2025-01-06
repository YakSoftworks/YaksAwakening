using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolManager : MonoBehaviour
{

    [SerializeField] private PlayerToolBase playerTool;


    #region DEBUG/OMITABLE

    ToolInputActions inputActions;

    private void Awake()
    {
        inputActions = new ToolInputActions();
    }


    private void SubscribeInputActions()
    {
        inputActions.Tools.RT.performed += RTActionPerformed;
        inputActions.Tools.RB.performed += RBActionPerformed;
        inputActions.Tools.LT.performed += LTActionPerformed;
        inputActions.Tools.LB.performed += LBActionPerformed;
    }

    private void UnSubscribeInputActions()
    {
        inputActions.Tools.RT.performed -= RTActionPerformed;
        inputActions.Tools.RB.performed -= RBActionPerformed;
        inputActions.Tools.LT.performed -= LTActionPerformed;
        inputActions.Tools.LB.performed -= LBActionPerformed;
    }

    private void Start()
    {
        SubscribeInputActions();
        inputActions.Tools.Enable();
    }

    private void OnDestroy()
    {
        inputActions.Tools.Disable();
        UnSubscribeInputActions();
    }




    #endregion


    #region Tool Actions
    //Bumper Actions
    //Assume to be secondary

    public void RBActionPerformed(InputAction.CallbackContext context)
    {
        playerTool.RBActionPerformed();
    }

    public void LBActionPerformed(InputAction.CallbackContext context)
    {
        playerTool.LBActionPerformed();

    }

    //Trigger Actions
    //Assume to be primary

    public void RTActionPerformed(InputAction.CallbackContext context)
    {
        playerTool.RTActionPerformed();
    }

    public void LTActionPerformed(InputAction.CallbackContext context)
    {
        playerTool.LTActionPerformed();
    }
    #endregion




}
