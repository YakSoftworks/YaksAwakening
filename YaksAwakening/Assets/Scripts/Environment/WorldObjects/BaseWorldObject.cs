using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseWorldObject : MonoBehaviour
{
    //Boolean for whether we can update on this tick
    private bool bCanUpdate = false;
    //Set function
    public void SetPauseObject(bool doUpdate)
    {
        bCanUpdate = doUpdate;
        Debug.Log($"{gameObject.name} : Current State: {bCanUpdate}");
    }


    //Always call the super when overridden
    protected virtual void Update()
    {
        //If we are not allowed to be updated, do nothing
        if (!bCanUpdate) { return; }

    }


    protected virtual bool CheckIsWithinRoomBounds()
    {
        Bounds roomBounds = GameManager.Instance.currentRoom.roomBounds;

        if (roomBounds.Contains(transform.position))
        {
            return true;
        }

        return false;


    }







}
