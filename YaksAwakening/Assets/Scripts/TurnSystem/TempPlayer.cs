using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "P_", menuName = "Turn/TempPlayer")]
public class TempPlayer : ScriptableObject, System.IComparable<TempPlayer>
{
    [SerializeField] private string name;


    [SerializeField] private List<BattleAction> availableActions = new List<BattleAction>();

    //DEBUG:::
    [SerializeField] private BattleAction DebugAction;

    [SerializeField] private TempPlayer target;

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

    public void IncrementTimeSinceLastAction(float increment)
    {
        timeSinceLastAction += increment;
    }

    public float GetCurrentBattleSpeed() {


        //Speed Equation
        float speed = ((baseSpeed + itemSpeed) * (strength / weight) * speedEffectMultiplier * timeSinceLastAction * turnSpeedMultiplier) + speedEffectBias;

        Debug.Log($"{name} has speed: {speed}");
        return speed;



    }

    public void TakeTurn(TurnManager manager)
    {
        //Take the action
        //Debug.Log($"{name} is taking their turn with speed: {speed * speedMultiplier * timeSinceLastAction * turnSpeedMultiplier}");
        //Debug.Log($"Base Speed: {speed}\tSpeedMultiplier: {speedMultiplier}\ttimeSinceLastAction: {timeSinceLastAction}\tTurnSpeedMultiplier: {turnSpeedMultiplier}");


        availableActions[Random.Range(0, availableActions.Count)].Act(this, target);


        //DebugAction.Act(this, target);
        //Set my time to next turn to minimum
        timeSinceLastAction = 0;

        //TELL OWNER TO TAKE IN INPUT
        //WAIT UNTIL INPUT GIVEN
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
            //Debug.Log($"{name} has {currentHealth} remaining");
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
}
