using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseWorldObject : MonoBehaviour
{
    //Boolean for whether we can update on this tick
    private bool bCanUpdate = false;

    public bool isActive { get { return bCanUpdate; } }

    private ResetableObject spawner;

    [SerializeField] private MonoBehaviour[] components;

    //Set function
    public void SetPauseObject(bool doUpdate)
    {
        bCanUpdate = doUpdate;
        Debug.Log($"{gameObject.name} : Current State: {bCanUpdate}");

        if (bCanUpdate)
        {
            //Enable each of the scripts
            foreach (MonoBehaviour behaviour in components)
            {
                behaviour.enabled = true;
            }
        }
        else
        {
            //Disable each of the scripts
            foreach(MonoBehaviour behaviour in components)
            {
                behaviour.enabled = false;
            }
        }
    }

    public void SetSpawner(ResetableObject resetSpawner)
    {
        spawner = resetSpawner;
    }


    //Always call the super when overridden
    protected virtual void Update()
    {
        //If we are not allowed to be updated, do nothing
        if (!bCanUpdate) { return; }

    }


    protected bool CheckIsWithinRoomBounds(Vector2 position)
    {
        Bounds roomBounds = GameManager.Instance.currentRoom.roomBounds;

        if (roomBounds.Contains(position))
        {
            return true;
        }

        return false;

    }







}
