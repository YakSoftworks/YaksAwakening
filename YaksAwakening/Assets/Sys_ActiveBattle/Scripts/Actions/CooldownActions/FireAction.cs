using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ABA_Fire", menuName = "ActiveBattle/Actions/Cooldown/Fire")]
public class FireAction : CooldownAction
{
    protected override bool ActionIsUsable(PlayerBattleController player)
    {
        return true;
    }

    protected override void AdditonalUpdates(float passedTime)
    {
        return;
    }

    protected override void PerformAction(PlayerBattleController player)
    {
        Debug.Log("Player Cast Fire!");
    }
}
