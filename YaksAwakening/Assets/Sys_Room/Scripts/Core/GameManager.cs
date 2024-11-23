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

    [SerializeField] public Room currentRoom
    {
        get;  private set;
    }

    public void SetCurrentRoom(Room room)
    {
        currentRoom = room;
    }

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

    

    #endregion
}