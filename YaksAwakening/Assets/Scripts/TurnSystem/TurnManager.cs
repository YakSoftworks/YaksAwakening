using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurnManager
{
    //Owned by a battle controller
    BattleController owningController;

    private List<TempPlayer> players;
    //Create a copy for each battle

    public float incrementTimeForTurns { get { return 1f / (players.Count) / 2f; } }

    //Initalize the turn system with the given teams
    public void InitializeTurnSystem(BattleController bc, List<TempPlayer> tempPlayers)
    {
        owningController = bc;
        players = tempPlayers;


    }

    //UPDATE WITH PROPER PLAYER/CHARACTER DATA




    //Function for handing the TurnManager the players Commented for debugging
    //public void SetPlayers(TempPlayer[] tempPlayers) { players = tempPlayers; }

    public void StartBattle()
    {

        //int debugCount = 10;

        //While both teams still have players
        while(owningController.battleInProgress)
        {

            TellNextPlayerToAct();

            //debugCount--;

            //if(debugCount < 0) { break; }
        }

        Debug.Log("Battle Over");
        



    }



    public void TellNextPlayerToAct()
    {

        //Sort players by speed stat
        //players.Sort(players[0]);
        players.Sort();

        Debug.Log(players[0].name);

        if (players.Count > 0)
        {
            players[0].TakeTurn(this);
        }

        IncrementPlayerTimes();


    }

    private void IncrementPlayerTimes()
    {
        //Debug.Log("Current Increment Time = " + incrementTimeForTurns);

        foreach(TempPlayer player in players)
        {
            //Increase the value for each player 
            player.IncrementTimeSinceLastAction(incrementTimeForTurns);
        }
    }

    public void PlayerDied(TempPlayer player)
    {
        players.Remove(player);
    }
}


