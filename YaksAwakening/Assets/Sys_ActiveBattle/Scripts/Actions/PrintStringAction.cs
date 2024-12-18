using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "A_DebugAction", menuName = "ActiveBattle/Actions/DebugAction")]
public class PrintStringAction : CharacterActions
{
    [SerializeField] private string message;

    public override void UpdateAction(float passedTime)
    {
        return;
    }

    protected override void Act(PlayerBattleController player)
    {
        Debug.Log(message);
    }

    protected override bool CheckIsUsable(PlayerBattleController player)
    {
        //Always Usable
        return true;
    }

    
}
