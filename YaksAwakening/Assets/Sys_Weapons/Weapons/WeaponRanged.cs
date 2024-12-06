using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedWeapon", menuName = "Weapons/Ranged")]
public class WeaponRanged : WeaponBase
{
    [SerializeField] private float gizmoRange;

    [Space(20)]
    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;

    public override void DrawWeaponGizmos(WeaponController controller)
    {
        Vector2 endPoint = controller.transform.position;
        endPoint = endPoint + (GetDirection(controller) * gizmoRange);
        if(gizmoRange == 0f)
        {
            Debug.LogError("Ranged Weapon Debug Set to 0!");
        }

        Gizmos.DrawLine(controller.transform.position, endPoint);
    }

    public override void UseWeapon(WeaponController controller)
    {
        //Create Item
        Projectile projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();
        
        //Set Postion and Rotation
        projectile.transform.SetPositionAndRotation(controller.transform.position, GetProjectileRotation(controller));
        
        //Enable
        projectile.enabled = true;

        //Tell it to go
        projectile.StartProjectile(GetDirection(controller));
    }

    //Returns a unit vector in the direction currently facing
    private Vector2 GetDirection(WeaponController controller) 
    {
        
        switch (controller.currentDirection)
        {
            case Direction.Up:
                return Vector2.up;

            case Direction.Down:
                return Vector2.down;

            case Direction.Left:
                return Vector2.left;

            case Direction.Right:
                return Vector2.right;
        }
        return Vector2.zero;
    
    }

    //returns a Vector3 containing the Euler Angles for the projectiles rotation
    private Quaternion GetProjectileRotation(WeaponController controller)
    {

        switch (controller.currentDirection)
        {
            case Direction.Up:
                return Quaternion.Euler(0, 0, 0);

            case Direction.Down:
                return Quaternion.Euler(0, 0, 180f);

            case Direction.Left:
                return Quaternion.Euler(0, 0, 270f);

            case Direction.Right:
                return Quaternion.Euler(0, 0, 90f);
        }
        return Quaternion.Euler(0, 0, 0);

    }

}
