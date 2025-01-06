using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tools/Debug/DebugTool", fileName = "T_DebugTool")]
public class DebugTool : PlayerToolBase
{


    public override void LBActionPerformed()
    {
        Debug.Log("LBAction");
    }

    public override void LTActionPerformed()
    {
        Debug.Log("LTAction");
    }

    public override void RBActionPerformed()
    {
        Debug.Log("RBAction");
    }

    public override void RTActionPerformed()
    {
        Debug.Log("RTAction");
    }


}
