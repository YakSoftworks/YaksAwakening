using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    //Rooms have three ideal states: Disabled, Enabled, Active
    //Active is when we are looking at the room
    //Enabled is when the room should be loaded but frozen
    //Disabled is when the room is to be reset




    //List of all Resetable Objects in the room
    [SerializeField] List<ResetableObject> respawnableItemsInScene;

    [SerializeField] private Room upRoom;
    [SerializeField] private Room downRoom;
    [SerializeField] private Room leftRoom;
    [SerializeField] private Room rightRoom;

    private bool isLoaded;


    #region Unity Functions
    private void Start()
    {

        ResetRoom();

        isLoaded = false;

    }

    #endregion

    public void ResetRoom()
    {

        for(int i=0;i<respawnableItemsInScene.Count; i++)
        {

            respawnableItemsInScene[i].CreateObject();

        }


    }

    #region Enable/Disable

    public void DisableRoom()
    {
        for (int i = 0; i < respawnableItemsInScene.Count; i++)
        {
            respawnableItemsInScene[i].DisableObject();
        }

        //Debug.Log("Room Disabled");
    }

    public void EnableRoom()
    {

        for(int i = 0; i < respawnableItemsInScene.Count; i++)
        {
            respawnableItemsInScene[i].EnableObject();
        }

        //Debug.Log("Room Enabled");
    }

    public void EnableNeighboringRooms()
    {

        if(upRoom != null)
        {
            upRoom.EnableRoom();
        }
        if (downRoom != null)
        {
            downRoom.EnableRoom();
        }
        if (leftRoom != null)
        {
            leftRoom.EnableRoom();
        }
        if (rightRoom != null)
        {
            rightRoom.EnableRoom();
        }

        
        
        

    }

    public void DisableNeighboringRooms(Direction directionMovedTo)
    {

        if(directionMovedTo!=Direction.Up && upRoom != null)
        {
            upRoom.DisableRoom();
        }
        if (directionMovedTo != Direction.Down && downRoom != null)
        {
            downRoom.DisableRoom();
        }
        if (directionMovedTo != Direction.Left && leftRoom != null)
        {
            leftRoom.DisableRoom();
        }
        if (directionMovedTo != Direction.Right && rightRoom != null)
        {
            rightRoom.DisableRoom();
        }


    }

    #endregion

    //TODO: Do whatever we need to do to unfreeze the objects in the room without reseting them
    public void ActivateRoom()
    {
        //If we are already loaded, do nothing
        if (isLoaded) { return; }

        //For now:
        EnableRoom();
    }

    //TODO: Do whatever we need to do to freeze the objects in the room without reseting them
    public void DeactivateRoom()
    {

        //For now:
        DisableRoom();
    }

    public Room GetRoomFromDirection(Direction direction)
    {

        switch (direction)
        {
            case Direction.Up:
                return upRoom;
            case Direction.Right:
                return rightRoom;
            case Direction.Down:
                return downRoom;
            case Direction.Left:
                return leftRoom;
            default:
                return null;
        }

    }


}
