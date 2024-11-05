using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "P_", menuName = "Turn/TempPlayer")]
public class TempPlayer : ScriptableObject, System.IComparable<TempPlayer>
{
    public string characterName;

    

    public BattleAction attackAction;

    public BattleAction waitAction;
    
    [SerializeField] private float maxHealth;

    [SerializeField] private float currentHealth;

    public BattleController owningController;

    [Header("STATS")]

    [SerializeField] private float strength;

    [SerializeField] private float weight;


    [Header("ATTACK")]

    [SerializeField] private float AttackPower;

    [SerializeField] private float AttackMultiplier;

    public float AttackStrength { get { return AttackPower * AttackMultiplier; } }


    [Header("SPEED")]

    [SerializeField] private float baseSpeed;

    [SerializeField] private float itemSpeed;


    //Multiplier that increases with time between actions
    //Allows for characters not to be overlapped too often
    [SerializeField] private float timeSinceLastAction = 1f;

    //Multiplier associated with the last turn taken
    //Allows for some actions to slow/speed you down/up
    [SerializeField] private float turnSpeedMultiplier = 1f;


    [SerializeField] private float speedEffectMultiplier = 1f;

    [SerializeField] private float speedEffectBias = 0f;

    private int currentTargetIndex=0;

    private TurnManager turnManager;

    //Add to our multiplier - Called in TurnManager
    public void IncrementTimeSinceLastAction(float increment)
    {
        timeSinceLastAction += increment;
    }

    //Get the player's current speed 
    public float GetCurrentBattleSpeed() {


        //Speed Equation
        float speed = ((baseSpeed + itemSpeed) * (strength / weight) * speedEffectMultiplier * timeSinceLastAction * turnSpeedMultiplier) + speedEffectBias;

        //Debug.Log($"{name} has speed: {speed}");
        return speed;



    }

    public void StartTurn(TurnManager manager)
    {

        Debug.Log("Starting Player Turn");

        //TODO: Future Update: Move from owningController to attached To Player In Scene
        //Tell the controller to bring up the actionMenu
        owningController.actionMenu.PromptPlayerAction(this);

        //Set the reference to the turn manager
        turnManager = manager;
    }

    //When the user has selected their action and target, they can take their action and prompt the manager to do the next turn
    //Called from the UI
    public void TakeTurn(BattleAction action, TempPlayer target)
    {
        //Do the action
        action.Act(this, target);
        

        //Reset our timer
        timeSinceLastAction = 0;

        //Tell the manger to do the next turn
        Debug.Log("Ending Turn");

        //Start the next turn
        turnManager.nextTurnEvent.Invoke();

    }

    //Update Our Multiplier - Used by BattleActions
    public void SetTurnSpeedMultiplier(float multiplier)
    {
        turnSpeedMultiplier = multiplier;
    }

    //Subtract float from our current health
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        //If our health = 0, we have died
        if (currentHealth < 1)
        {
            Debug.Log($"{name} has died!");
            
            owningController.PlayerDied(this);

        }
        //Otherwise we are still alive
        else
        {
            Debug.Log($"{name} has {currentHealth} remaining");
        }


    }

    //Compare the currentSpeeds between two players
    public int CompareTo(TempPlayer other)
    {

        return 1-(GetCurrentBattleSpeed().CompareTo(other.GetCurrentBattleSpeed()));
    }

    //Choose a random target from our enemies
    public TempPlayer GetRandomTarget()
    {
        //Get our enemies from the controller
        List<TempPlayer> enemies = owningController.GetEnemies(this);

        //return a random enemy
        return enemies[Random.Range(0, enemies.Count)];

    }

    //Get our last indexedTarget
    public TempPlayer GetInitialTarget()
    {
        //TODO: Fix for alive/dead enemies
        List<TempPlayer> enemies = owningController.GetEnemies(this); // Get our enemies
        return enemies[currentTargetIndex % enemies.Count]; // Mod in case the index died and become out of bounds
    }

    public void IncrementCurrentTarget(int increment)
    {
        //If we are targeting
        if (owningController.GetIsTargeting())
        {
            //get our enemies
            List<TempPlayer> enemies = owningController.GetEnemies(this);

            //Get the new index
            currentTargetIndex = ((currentTargetIndex+increment)+enemies.Count)%enemies.Count;

            //Update the UI
            owningController.UpdateActionUI(enemies[currentTargetIndex]);
        }


    }
}
