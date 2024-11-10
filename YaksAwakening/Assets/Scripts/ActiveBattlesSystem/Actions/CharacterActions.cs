using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterActions : ScriptableObject
{

    [SerializeField] private float coolDownTime;

    private Coroutine actionCooldownCoroutine;

    float timeInCooldown = 0f;
    
    public bool isInCooldown { get {return timeInCooldown < coolDownTime;} }

    public bool IsUsable(PlayerBattleController player)
    {
        //First Check if we are coolingDown
        if (isInCooldown) { return false; }


        //then run our own check to see if we are usable
        return CheckIsUsable(player);


    }

    protected abstract bool CheckIsUsable(PlayerBattleController player);

    public void UseAction(PlayerBattleController player)
    {
        //Make sure we are usable
        if(!IsUsable(player)) { Debug.Log("Action is in Cooldown");  return; }

        //Perform our action
        Act(player);

        //Reset our cooldown
        timeInCooldown = 0f;

    }

    protected abstract void Act(PlayerBattleController player);

    public void UpdateAction(float passedTime)
    {
        //If we are in cooldown
        if(isInCooldown)
        {
            //Increment our timeInCooldown
            timeInCooldown += passedTime;
            //Debug.Log($"Cooldown = {timeInCooldown} : {coolDownTime}");
        }


    }

}
