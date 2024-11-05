using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

//UI Controller for the action menu
//Made only for Attack and Wait as actions

public class BattleActionMenu : MonoBehaviour
{
    [SerializeField] private UIDocument ui;

    #region VisualElements

    private VisualElement rootElement;

    private VisualElement actionContainer;

    private Button attackButton;

    private Button waitButton;

    private VisualElement targetingContainer;

    private Label currentTargetLabel;

    #endregion

    private TempPlayer attachedPlayer;

    private TempPlayer currentTarget;

    private BattleAction selectedAction;

    private TurnMode currentMode;

    public bool IsTargeting { get { return currentMode == TurnMode.TargetingPlayer; } }

    private void Start()
    {

        rootElement = ui.rootVisualElement;

        //Get a reference to each of our buttons

        attackButton = rootElement.Q<Button>("AttackButton");
        waitButton = rootElement.Q<Button>("WaitButton");

        actionContainer = rootElement.Q<VisualElement>("ActionContainer");
        targetingContainer = rootElement.Q<VisualElement>("TargetingContainer");

        currentTargetLabel = rootElement.Q<Label>("TargetName");



        //rootElement.style.visibility = Visibility.Hidden;

        attackButton.clicked += AttackButtonPressed;

        waitButton.clicked += WaitButtonPressed;

        //Hide our menus
        actionContainer.style.visibility = Visibility.Hidden;

        targetingContainer.style.visibility = Visibility.Hidden;
        

    }

    private void OnDestroy()
    {
        attackButton.clicked -= AttackButtonPressed;

        waitButton.clicked -= WaitButtonPressed;
    }

    
    public void PromptPlayerAction(TempPlayer player)
    {
        //Reset our currentMode
        currentMode = TurnMode.SelectingAction;
        Debug.Log("PromptMenu showing");

        //Show our actionMenu
        actionContainer.style.visibility = Visibility.Visible;
        //Set player reference
        attachedPlayer = player;
    }

    private void AttackButtonPressed()
    {
        Debug.Log("Attack Button Clicked");
        //If we were targeting a player, we will use the action
        if (IsTargeting)
        {
            //Hide the menus
            targetingContainer.style.visibility = Visibility.Hidden;
            actionContainer.style.visibility = Visibility.Hidden;
            //tell the player to take their turn
            attachedPlayer.TakeTurn(attachedPlayer.attackAction, currentTarget);
            return;
        }
        //Otherwise,

        //Enter the targeting mode
        currentMode = TurnMode.TargetingPlayer;
        //Set our selected action as our chosen action
        selectedAction = attachedPlayer.attackAction;

        //Select our inital currentTarget
        currentTarget = attachedPlayer.GetInitialTarget();

        //Update the text in the UI
        currentTargetLabel.text = currentTarget.characterName;
        Debug.Log("New Target: " + currentTarget.characterName);

        //Show our targeting UI
        targetingContainer.style.visibility = Visibility.Visible;


    }

    private void WaitButtonPressed()
    {
        Debug.Log("Wait Button Clicked");
        //Tell the player to take a wait action
        actionContainer.style.visibility = Visibility.Hidden;
        targetingContainer.style.visibility = Visibility.Hidden;
        attachedPlayer.TakeTurn(attachedPlayer.waitAction, null);
        
    }

    public void UpdateCurrentTarget(TempPlayer newTarget)
    {
       //Check to see if we are targeting
       if(IsTargeting)
        {
            //Update our currentTarget
            currentTarget = newTarget;
            //Update the UI Label with their name
            currentTargetLabel.text = newTarget.characterName;
            Debug.Log("New Target: "+ newTarget.characterName);
        }
    }

    //Way of managing different states of the actionMenu
    private enum TurnMode
    {
        SelectingAction,
        TargetingPlayer
    }

    //Called when we need to end the battle
    public void EndBattle()
    {
        //Hide 
        actionContainer.style.visibility = Visibility.Hidden;
        targetingContainer.style.visibility = Visibility.Hidden;

        //Maybe Do More
        Debug.Log("Congratulations Winning Team...");
    }






}
