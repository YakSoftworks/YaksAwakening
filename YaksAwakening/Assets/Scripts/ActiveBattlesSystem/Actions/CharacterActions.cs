using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterActions : ScriptableObject
{

    public bool IsUsable(PlayerBattleController player)
    {
        return CheckIsUsable(player);

    }

    protected abstract bool CheckIsUsable(PlayerBattleController player);

    public void UseAction(PlayerBattleController player)
    {

        if(!IsUsable(player)) { Debug.Log("Action is Not Usable");  return; }

        Act(player);


    }

    protected abstract void Act(PlayerBattleController player);

    public abstract void UpdateAction(float passedTime);

    

}
