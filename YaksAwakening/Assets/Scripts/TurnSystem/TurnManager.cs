using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TurnManager
{
    //Owned by a battle controller
    BattleController owningController;

    private List<TempPlayer> players;
    //Create a copy for each battle

    public float incrementTimeForTurns { get { return 1f / (players.Count) / 2f; } }

    public UnityEvent nextTurnEvent = new UnityEvent();

    public TempPlayer currentPlayer;

    //Initalize the turn system with the given teams
    public void InitializeTurnSystem(BattleController bc, List<TempPlayer> tempPlayers)
    {
        owningController = bc;
        players = tempPlayers;


        //Whenever this event is called, the next turn can start
        nextTurnEvent.AddListener(TellNextPlayerToAct);


    }


    private void TellNextPlayerToAct()
    {
        //Step 1: Check if battle is over
        if (!owningController.battleInProgress)
        {
            Debug.Log("battle over");
            owningController.EndBattle();
            
        }

        //Step 2: Increment times for players
        IncrementPlayerTimes();

        //Step 3: Figure out which player is next

        //Sort players by speed stat
        players.Sort();
        //Fastest Player is at index 0

        //Step 4: Tell the player to take their turn
        if (players.Count > 0)
        {
            //Tell the fastest player they can act
            Debug.Log("Start1");
            currentPlayer = players[0];
            players[0].StartTurn(this);

        }

        //Wait until player acts then we will call this again
        


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


