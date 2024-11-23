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
        Debug.Log("Deactivate 1");
        currentRoom.DeactivateRoom();

        //Disable our neighbors except for the one we are going into
        currentRoom.DisableNeighboringRooms(direction);

        //Update CurrentRoom
        currentRoom = currentRoom.GetRoomFromDirection(direction);

        //Enable the rooms neighboring us
        currentRoom.EnableNeighboringRooms();

        Debug.Log("Changing Rooms");

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
}
