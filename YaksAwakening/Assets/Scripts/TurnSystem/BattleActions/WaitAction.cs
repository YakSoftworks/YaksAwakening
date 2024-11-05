using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaitAction", menuName = "Turn/Actions/Wait")]
public class WaitAction : BattleAction
{
    public override void Act(TempPlayer actor, TempPlayer target)
    {
        if (target != null) { Debug.Log($"{actor.name} used {name} against {target.name}"); }
        GiveActorSpeedMultiplier(actor);

        

    }

}
