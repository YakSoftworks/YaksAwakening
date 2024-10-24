using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Variables

    #region Singleton

    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    #endregion

    #region Rooms

    [SerializeField] private Room currentRoom;

    #endregion

    private GameState gameState;


    #endregion

    #region Unity Functions

    private void Awake()
    {

        if (_instance == null)
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


        gameState = GameState.Instance;

        ResumeGame();
    }

    #endregion

    #region Custom Functions

    public void TogglePause()
    {
        if (gameState.IsPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        bool didResume = gameState.UpdateGameStatus(GameStatus.Playing);

        if (didResume)
        {
            Time.timeScale = 1;
        }
    }

    public void PauseGame()
    {
        bool didPause = gameState.UpdateGameStatus(GameStatus.Paused);

        if (didPause)
        {
            Time.timeScale = 0;
        }
    }

    //Returns true if perfectly able to change rooms
    public bool ChangeRoomUsingDirection(Direction direction)
    {

        Room nextRoom = currentRoom.GetRoomFromDirection(direction);

        //Check to make sure there is a room we can go to
        if (nextRoom == null) { return false; }

        //Pause the currentRoom
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
            currentRoom.ActivateRoom();
        }
         
    }

    #endregion
}