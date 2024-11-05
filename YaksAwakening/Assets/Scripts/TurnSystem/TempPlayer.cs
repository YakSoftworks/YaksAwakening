using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "P_", menuName = "Turn/TempPlayer")]
public class TempPlayer : ScriptableObject, System.IComparable<TempPlayer>
{
    [SerializeField] private string name;


    public BattleAction attackAction;

    public BattleAction waitAction;

    //DEBUG:::
    [SerializeField] private BattleAction DebugAction;

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

    private TurnManager turnManager;

    public void IncrementTimeSinceLastAction(float increment)
    {
        timeSinceLastAction += increment;
    }

    public float GetCurrentBattleSpeed() {


        //Speed Equation
        float speed = ((baseSpeed + itemSpeed) * (strength / weight) * speedEffectMultiplier * timeSinceLastAction * turnSpeedMultiplier) + speedEffectBias;

        //Debug.Log($"{name} has speed: {speed}");
        return speed;



    }

    public void StartTurn(TurnManager manager)
    {

        Debug.Log("Starting Player Turn");
        owningController.actionMenu.PromptPlayerAction(this);

        //This function is to bring up the prompt for the player to take their turn

        //Set the reference to the turn manager
        turnManager = manager;
    }

    //When the user has selected their action and target, they can take their action and prompt the manager to do the next turn
    public void TakeTurn(BattleAction action, TempPlayer target)
    {
        //Do the action
        action.Act(this, target);
        

        //Reset our timer
        timeSinceLastAction = 0;

        //Tell the manger to do the next turn
        Debug.Log("Ending Turn");
        
        turnManager.nextTurnEvent.Invoke();

    }

    public void SetTurnSpeedMultiplier(float multiplier)
    {
        turnSpeedMultiplier = multiplier;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth < 1)
        {
            Debug.Log($"{name} has died!");
            
            owningController.PlayerDied(this);

        }
        else
        {
            Debug.Log($"{name} has {currentHealth} remaining");
        }


    }

    public void ResetMultipliers()
    {
        turnSpeedMultiplier = 1f;
        timeSinceLastAction = 1f;

        currentHealth = maxHealth;


    }

    public int CompareTo(TempPlayer other)
    {
        return 1-(GetCurrentBattleSpeed().CompareTo(other.GetCurrentBattleSpeed()));
    }

    public TempPlayer GetRandomTarget()
    {
        List<TempPlayer> enemies = owningController.GetEnemies(this);

        return enemies[Random.Range(0, enemies.Count)];

    }
}
