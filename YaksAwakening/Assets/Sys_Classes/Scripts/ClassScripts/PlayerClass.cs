using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerClass", menuName = "Classes/Class")]
public class PlayerClass : ScriptableObject
{

    [SerializeField] private List<ClassAbility> abilities = new List<ClassAbility>(3);

    public void UseAbility(int abilityNum)
    {
        if (abilities[abilityNum] != null)
        {
            Debug.Log("using Move: " + abilities[abilityNum].name);
        }
        else
        {
            Debug.Log("No Ability Set");
        }
        
    }





}
