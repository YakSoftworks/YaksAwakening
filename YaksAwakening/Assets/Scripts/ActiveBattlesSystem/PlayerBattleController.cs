using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ABC_Controller", menuName = "ActiveBattle/Controller")]
public class PlayerBattleController : ScriptableObject
{
    //List of character actions 0-9 are keys 1-0; 10/11 are L/R Mouse Buttons
    [Tooltip("Must contain 12 values, even if values are null")]
    [SerializeField] private List<CharacterActions> actions = new List<CharacterActions>(12);

    public void UpdateBattleController(float passedTime)
    {
        foreach (CharacterActions action in actions)
        {
            if (action != null)
            {
                action.UpdateAction(passedTime);
            }
        }
    }

    
    public void TriggerAction(int actionIndex)
    {
        if (actions[actionIndex] == null) { Debug.Log("No Action Assigned"); return; }


        actions[actionIndex].UseAction(this);
    }



}
