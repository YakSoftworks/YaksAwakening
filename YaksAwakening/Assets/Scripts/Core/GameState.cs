using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour
{

    #region Variables

    #region Singleton

    private static GameState _instance;

    public static GameState Instance
    {
        get { return _instance; }
    }

    #endregion

    private bool isPaused;

    private GameStatus currentGameStatus;

    public UnityEvent OnGameResumed;

    public UnityEvent OnGamePaused;

    #endregion

    #region Unity Functions

    private void Awake()
    {

        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        ResetGameStatus();



    }

    #endregion

    #region Custom Functions

    public bool UpdateGameStatus(GameStatus newGameStatus)
    {
        if(currentGameStatus == newGameStatus)
        {
            return false;
        }

        currentGameStatus = newGameStatus;

        switch (newGameStatus)
        {
            case GameStatus.Playing:
                OnGameResumed.Invoke();
                break;

            case GameStatus.Paused:
                OnGamePaused.Invoke();
                break;

            default:
                Debug.LogError("Attempted Improper Game Status");
                break;
        }

        return true;

    }

    private void ResetGameStatus()
    {

        Debug.Log("Resetting Game Status");

        currentGameStatus = GameStatus.Paused;

        OnGamePaused.RemoveAllListeners();
        OnGameResumed.RemoveAllListeners();


    }

    public bool IsPaused => currentGameStatus == GameStatus.Paused;


    #endregion



}



public enum GameStatus
{
    Playing,
    Paused
}