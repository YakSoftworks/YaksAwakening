using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BattleController : MonoBehaviour
{
    public TurnManager turnManager;

    [SerializeField] private List<TempPlayer> teamA = new List<TempPlayer>();

    [SerializeField] private List<TempPlayer> teamB = new List<TempPlayer>();

    public BattleActionMenu actionMenu;

    private int teamALivesRemaining = 0;
    private int teamBLivesRemaining = 0;

    public bool battleInProgress { get { return teamALivesRemaining > 0 && teamBLivesRemaining > 0; } }

    private void Start()
    {
        Debug.Log("BattleStarting");

        teamALivesRemaining = teamA.Count;
        teamBLivesRemaining = teamB.Count;

        Debug.Log($"Team A: {teamALivesRemaining}\tTeam B: {teamBLivesRemaining}");

        List<TempPlayer> players = new List<TempPlayer>(teamA.Count+teamB.Count);

        CreatePlayerList(players);
        

        //Initalize the turnManager
        turnManager.InitializeTurnSystem(this, players);

        //Start the battle
        turnManager.nextTurnEvent.Invoke();

    }

    public void PlayerDied(TempPlayer player)
    {
        if (teamA.Contains(player))
        {
            teamALivesRemaining--;
        }

        else if (teamB.Contains(player))
        {
            teamBLivesRemaining--;
        }
        Debug.Log($"Team A: {teamALivesRemaining}\tTeam B: {teamBLivesRemaining}");
        turnManager.PlayerDied(player);



    }

    private void CreatePlayerList(List<TempPlayer> players)
    {

        foreach(TempPlayer player in teamA)
        {
            player.owningController = this;
            players.Add(player);
        }
        foreach (TempPlayer player in teamB)
        {
            player.owningController = this;
            players.Add(player);
        }


    }

    public void EndBattle()
    {
        //Do something
        Debug.Log("The battle has ended");
    }

    public List<TempPlayer> GetEnemies(TempPlayer player)
    {
        if (teamA.Contains(player))
        {
            return teamB;
        }

        else
        {
            return teamA;
        }
    }

    public void UpdateActionUI(TempPlayer newTarget)
    {
        actionMenu.UpdateCurrentTarget(newTarget);
    }

    public bool GetIsTargeting()
    {
        return actionMenu.IsTargeting;
    }



}
