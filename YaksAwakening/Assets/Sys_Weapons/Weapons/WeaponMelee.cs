using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon_Standard", menuName = "Weapons/Melee")]

public class WeaponMelee : WeaponBase
{
    //Sizes of the boxCast Box
    [SerializeField] private float range = .5f;
    [SerializeField] private float width = .5f;

    [Space(10)]
    [SerializeField] private float castDistance = 1.25f;

    public override void UseWeapon(WeaponController controller)
    {
        ThreeVectorStruct twinVectors = GetVectorsForShape(controller.currentDirection);

        RaycastHit2D[] hits = Physics2D.BoxCastAll(twinVectors.vectorA, twinVectors.vectorB, 0f, twinVectors.vectorC, castDistance);

        foreach(RaycastHit2D hit in hits)
        {

            Debug.Log("Hit " + hit.collider.name);


        }
    }

    public override void DrawWeaponGizmos(WeaponController controller)
    {
        Gizmos.color = debug_Color;

        ThreeVectorStruct twinVectors = GetVectorsForShape(controller.currentDirection);
        twinVectors.vectorA += controller.transform.position;

        Gizmos.DrawWireCube(twinVectors.vectorA, twinVectors.vectorB);
    }



    private ThreeVectorStruct GetVectorsForShape(Direction direction)
    {
        ThreeVectorStruct twinVector = new ThreeVectorStruct();

        switch (direction)
        {
            case Direction.Up:
                twinVector.vectorA = new Vector3(0f, castDistance);
                twinVector.vectorB = new Vector3(width, range);
                twinVector.vectorC = Vector3.up;
                break;

            case Direction.Down:
                twinVector.vectorA = new Vector3(0f, -castDistance);
                twinVector.vectorB = new Vector3(width, range);
                twinVector.vectorC = Vector3.down;
                break;
            case Direction.Left:
                twinVector.vectorA = new Vector3(-castDistance, 0f);
                twinVector.vectorB = new Vector3(range, width);
                twinVector.vectorC = Vector3.left;
                break;
            case Direction.Right:
                twinVector.vectorA = new Vector3(castDistance, 0f);
                twinVector.vectorB = new Vector3(range, width);
                twinVector.vectorC = Vector3.right;
                break;
        }




        return twinVector;
    }

    private struct ThreeVectorStruct 
    {
        public Vector3 vectorA;
        public Vector3 vectorB;
        public Vector3 vectorC;
    }

}
