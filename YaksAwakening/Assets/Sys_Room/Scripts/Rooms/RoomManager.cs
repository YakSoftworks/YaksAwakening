using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    #region Singleton

    private static RoomManager _instance;

    public static RoomManager Instance {  get { return _instance; } }


    #endregion

    // Referecne to the room to initalize the game with
    [SerializeField] private Room startingRoom;

    private Room currentRoom;


    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }



    }
    private void Start()
    {
        //Enablke
        startingRoom.EnableRoom();
        startingRoom.ActivateRoom();

        currentRoom = startingRoom;
    }


    //Returns true if perfectly able to change rooms
    public bool ChangeRoomUsingDirection(Direction direction)
    {

        Room nextRoom = currentRoom.GetRoomFromDirection(direction);

        //Check to make sure there is a room we can go to
        if (nextRoom == null) { return false; }

        //Pause the currentRoom
        //Debug.Log("Deactivate 1");
        currentRoom.DeactivateRoom();

        //Disable our neighbors except for the one we are going into
        DisableNeighboringRooms(currentRoom, direction);

        //Update CurrentRoom
        currentRoom = currentRoom.GetRoomFromDirection(direction);

        //Enable the rooms neighboring us
        EnableNeighboringRooms(currentRoom);

        //Debug.Log("Changing Rooms");

        return true;

    }

    public void EnableCurrentRoom()
    {


        if (currentRoom != null)
        {
            Debug.Log("Enabling Room");
            currentRoom.ActivateRoom();
        }
        else
        {
            Debug.LogWarning("CURRENT ROOM IS NULL ");
        }

    }

    public void DisableCurrentRoom()
    {
        if (currentRoom != null)
        {
            Debug.Log("Disabling Room");
            currentRoom.DeactivateRoom();
        }
    }


    public void EnableNeighboringRooms(Room currentRoom)
    {

        if (currentRoom.roomAbove != null)
        {
            currentRoom.roomAbove.EnableRoom();
        }
        if (currentRoom.roomBelow != null)
        {
            currentRoom.roomBelow.EnableRoom();
        }
        if (currentRoom.roomLeft != null)
        {
            currentRoom.roomLeft.EnableRoom();
        }
        if (currentRoom.roomRight != null)
        {
            currentRoom.roomRight.EnableRoom();
        }





    }

    public void DisableNeighboringRooms(Room currentRoom, Direction directionMovedTo)
    {

        if (directionMovedTo != Direction.Up && currentRoom.roomAbove != null)
        {
            currentRoom.roomAbove.DisableRoom();
        }
        if (directionMovedTo != Direction.Down && currentRoom.roomBelow != null)
        {
            currentRoom.roomBelow.DisableRoom();
        }
        if (directionMovedTo != Direction.Left && currentRoom.roomLeft != null)
        {
            currentRoom.roomLeft.DisableRoom();
        }
        if (directionMovedTo != Direction.Right && currentRoom.roomRight != null)
        {
            currentRoom.roomRight.DisableRoom();
        }


    }


}
