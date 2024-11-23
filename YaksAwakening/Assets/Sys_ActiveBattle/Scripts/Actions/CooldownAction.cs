using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CooldownAction : CharacterActions
{
    [SerializeField] private float cooldownTime;

    private float timeSinceUse = 0;

    #region Update

    public override void UpdateAction(float passedTime)
    {
        //Increment timeSinceUse
        if (timeSinceUse < cooldownTime) { timeSinceUse += passedTime; }

        AdditonalUpdates(passedTime);

    }

    protected abstract void AdditonalUpdates(float passedTime);

    #endregion
    #region Perform Action

    protected override void Act(PlayerBattleController player)
    {
        //Reset our timer
        timeSinceUse = 0f;

        //Perform our action
        PerformAction(player);

    }

    protected abstract void PerformAction(PlayerBattleController player);

    #endregion
    #region IsUsable

    protected override bool CheckIsUsable(PlayerBattleController player)
    {
        // First check if we have cooled down
        if(timeSinceUse < cooldownTime) { return false; }

        // Next check the individual condition
        return ActionIsUsable(player);

    }

    protected abstract bool ActionIsUsable(PlayerBattleController player);

    #endregion

}
