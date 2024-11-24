using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponBase lWeapon;

    [SerializeField] private WeaponBase rWeapon;



    public Direction currentDirection = Direction.Right;


    public void UseLeft()
    {

        Debug.Log("Using Left Weapon");

        if (lWeapon != null)
        {

            //Use Left Weapon if it exists
            lWeapon.UseWeapon(this);
            

        }
    }


    public void UseRight()
    {

        Debug.Log("Using Right Weapon");

        if (rWeapon != null)
        {

            //Use Right Weapon if it exists


        }
    }

    private void OnDrawGizmos()
    {
        if(lWeapon != null)
        {
            lWeapon.DrawWeaponGizmos(this);
        }

        if (rWeapon != null)
        {
            rWeapon.DrawWeaponGizmos(this);
        }
    }
}
