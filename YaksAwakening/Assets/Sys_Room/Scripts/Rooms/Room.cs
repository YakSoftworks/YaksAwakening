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

    public Room roomAbove { get { return upRoom; } }
    public Room roomBelow { get { return downRoom; } }
    public Room roomLeft { get { return leftRoom; } }
    public Room roomRight { get { return rightRoom; } }

    private RoomStatus currentRoomStatus = RoomStatus.Disabled;




    //[Header("Room Details")]

    public Bounds roomBounds;

    //The distances from the center to the end in x and y
    public static Vector2 roomSize
    {
        get { return new Vector2(8, 6); }
    }



    #region Unity Functions
    private void Start()
    {

        ResetRoom();

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
        //Only disable if we are currently enabled
        if(currentRoomStatus != RoomStatus.Enabled) {  return; } 

        //Tell the room to reset itself
        ResetRoom();

        for (int i = 0; i < respawnableItemsInScene.Count; i++)
        {
            respawnableItemsInScene[i].DisableObject();
        }

        currentRoomStatus = RoomStatus.Disabled;

    }

    public void EnableRoom()
    {
        //If we are already enabled don't re-enable it
        if(currentRoomStatus == RoomStatus.Enabled) { return; }

        //Enable all objects within the room
        for (int i = 0; i < respawnableItemsInScene.Count; i++)
        {
            respawnableItemsInScene[i].EnableObject();
        }

        currentRoomStatus = RoomStatus.Enabled; 
    }

    #endregion


    #region Activate/Deactivate
    public void ActivateRoom()
    {
        //Don't activate if we are already active
        if(currentRoomStatus == RoomStatus.Active) { return; }

        ActivateRoomObjects();

        currentRoomStatus = RoomStatus.Active;

    }

    public void DeactivateRoom()
    {
        //Only Deactivate if we are active
        if(currentRoomStatus != RoomStatus.Active) { return;}

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

    private enum RoomStatus
    {
        Active,
        Enabled,
        Disabled
    }

}
