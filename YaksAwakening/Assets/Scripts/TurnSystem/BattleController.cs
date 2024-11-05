using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BattleController : MonoBehaviour
{
    public TurnManager turnManager;

    //Manage our teams
    [SerializeField] private List<TempPlayer> teamA = new List<TempPlayer>();

    [SerializeField] private List<TempPlayer> teamB = new List<TempPlayer>();

    public BattleActionMenu actionMenu;

    //Manage the remaining lives per team
    private int teamALivesRemaining = 0;
    private int teamBLivesRemaining = 0;

    //Check to see if either team has no lives left
    public bool battleInProgress { get { return teamALivesRemaining > 0 && teamBLivesRemaining > 0; } }

    private void Start()
    {
        Debug.Log("BattleStarting");
        //Set our livesRemaining based on our teams
        teamALivesRemaining = teamA.Count;
        teamBLivesRemaining = teamB.Count;

        Debug.Log($"Team A: {teamALivesRemaining}\tTeam B: {teamBLivesRemaining}");

        //Put all charcters into a single list
        List<TempPlayer> players = new List<TempPlayer>(teamA.Count+teamB.Count);
        CreatePlayerList(players);
        

        //Initalize the turnManager
        turnManager.InitializeTurnSystem(this, players);

        //Start the battle
        turnManager.nextTurnEvent.Invoke();

    }

    public void PlayerDied(TempPlayer player)
    {
        //Depending on which team they were in, subtract a life
        if (teamA.Contains(player))
        {
            teamALivesRemaining--;
        }

        else if (teamB.Contains(player))
        {
            teamBLivesRemaining--;
        }
        Debug.Log($"Team A: {teamALivesRemaining}\tTeam B: {teamBLivesRemaining}");

        //Tell the turnManager that this player needs to be removed from the list of players
        turnManager.PlayerDied(player);



    }

    //Helper to put all players into a single list
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

    //Do something to end the battle; Unknown Currently
    public void EndBattle()
    {
        actionMenu.EndBattle();
        //Do something
        Debug.Log("The battle has ended");
    }

    //Get the players who are not on the given player's team
    public List<TempPlayer> GetEnemies(TempPlayer player)
    {
        //Get the alive players in the opposing team
        if (teamA.Contains(player))
        {
            return GetAlivePlayers(teamB);
        }

        else
        {
            return GetAlivePlayers(teamA);
        }
    }

    //Tell the actionMenu to update
    public void UpdateActionUI(TempPlayer newTarget)
    {
        actionMenu.UpdateCurrentTarget(newTarget);
    }

    //Check to see if the actionMenu is in its targetingMode
    public bool GetIsTargeting()
    {
        return actionMenu.IsTargeting;
    }

    //Get a list base on a given list of players still alive
    private List<TempPlayer> GetAlivePlayers(List<TempPlayer> playersToCheck)
    {
        List<TempPlayer> alivePlayers = new List<TempPlayer>();

        foreach(TempPlayer player in playersToCheck)
        {
            if (turnManager.IsPlayerAlive(player))
            {
                alivePlayers.Add(player);
            }
        }

        return alivePlayers;


    }



}
