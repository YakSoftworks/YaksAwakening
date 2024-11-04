using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleAction : ScriptableObject
{

    public string name;

    public float power;

    public float speedMultiplier; //Allows for some actions to prevent the player from acting sooner than later

    //Function to define the specific action
    //Make sure to include GiveActorSpeedMultiplier
    public abstract void Act(TempPlayer actor, TempPlayer target);


    protected void GiveActorSpeedMultiplier(TempPlayer actor)
    {
        //Give the actor the speed multiplier associated with this action
        
        actor.SetTurnSpeedMultiplier(speedMultiplier);

    }



}
