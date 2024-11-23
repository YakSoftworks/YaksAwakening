using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackAction", menuName = "Turn/Actions/Attack")]
public class AttackAction : BattleAction
{
    public override void Act(TempPlayer actor, TempPlayer target)
    {
        GiveActorSpeedMultiplier(actor);

        Debug.Log($"{actor.name} dealt {power * actor.AttackStrength / 100f} damage against {target.name}");
        target.TakeDamage(power * actor.AttackStrength / 100f);
    }
}
