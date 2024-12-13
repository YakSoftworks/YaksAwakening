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

    //[Header("Room Details")]

    public Bounds roomBounds;

    bool isLoaded;

    //The distances from the center to the end in x and y
    public static Vector2 roomSize
    {
        get { return new Vector2(8, 6); }
    }



    #region Unity Functions
    private void Start()
    {

        ResetRoom();

        isLoaded = false;

        roomBounds = new Bounds(transform.position, roomSize);

        DeactivateRoomObjects();

    }

    #endregion

    public void ResetRoom()
    {

        for(int i=0;i<respawnableItemsInScene.Count; i++)
        {

            respawnableItemsInScene[i].CreateObject();

        }

        DeactivateRoom();


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

    #region Enable/Disable

    public void DisableRoom()
    {

        //Tell the room to reset itself
        ResetRoom();

        for (int i = 0; i < respawnableItemsInScene.Count; i++)
        {
            respawnableItemsInScene[i].DisableObject();
        }


    }

    public void EnableRoom()
    {
        

        //Enable all objects within the room
        for (int i = 0; i < respawnableItemsInScene.Count; i++)
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


    #region Activate/Deactivate
    public void ActivateRoom()
    {
        ActivateRoomObjects();
    }

    public void DeactivateRoom()
    {
        Debug.Log("Deactivate 2");
        DeactivateRoomObjects();
        Debug.Log("Deactivate 3");
    }

    #region Activate/Deactive Objects

    private void DeactivateRoomObjects()
    {
        for (int i = 0; i < respawnableItemsInScene.Count; i++)
        {
            respawnableItemsInScene[i].SetObjectUpdateStatus(false);
        }
    }

    private void ActivateRoomObjects()
    {
        for (int i = 0; i < respawnableItemsInScene.Count; i++)
        {
            respawnableItemsInScene[i].SetObjectUpdateStatus(true);
        }
    }

    #endregion
    #endregion


}
