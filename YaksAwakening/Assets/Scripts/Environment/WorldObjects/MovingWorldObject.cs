using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWorldObject : BaseWorldObject
{

    [Tooltip("Boolean describing if an object may select a destination outside the bounds of the room")]
    [SerializeField] private bool canExitRoom;
    

    public void UpdateObject()
    {

    



    }

    public void WorldObjectTryingToExitScene()
    {
        //Honestly who knows...
        if (!canExitRoom)
        {
            Destroy(gameObject);
        }
    }



}
