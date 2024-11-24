using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public abstract class WeaponBase : ScriptableObject
{

    [SerializeField] protected Color debug_Color = Color.red;

    //The weapon decides how it will handle the attack
    public abstract void UseWeapon(WeaponController controller);

    public abstract void DrawWeaponGizmos(WeaponController controller);


}
