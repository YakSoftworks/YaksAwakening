using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class BattleActionMenu : MonoBehaviour
{
    [SerializeField] private UIDocument ui;

    private VisualElement rootElement;

    private VisualElement actionContainer;

    private Button attackButton;

    private Button waitButton;

    private VisualElement targetingContainer;

    private Label currentTargetLabel;

    private TempPlayer attachedPlayer;

    private TempPlayer currentTarget;

    private BattleAction selectedAction;

    private TurnMode currentMode;

    public bool IsTargeting { get { return currentMode == TurnMode.TargetingPlayer; } }

    private void Start()
    {

        rootElement = ui.rootVisualElement;


        attackButton = rootElement.Q<Button>("AttackButton");
        waitButton = rootElement.Q<Button>("WaitButton");

        actionContainer = rootElement.Q<VisualElement>("ActionContainer");
        targetingContainer = rootElement.Q<VisualElement>("TargetingContainer");

        currentTargetLabel = rootElement.Q<Label>("TargetName");



        //rootElement.style.visibility = Visibility.Hidden;

        attackButton.clicked += AttackButtonPressed;

        waitButton.clicked += WaitButtonPressed;

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
        currentMode = TurnMode.SelectingAction;

        //Reset internal variables
        Debug.Log("PromptMenu showing");

        actionContainer.style.visibility = Visibility.Visible;
        attachedPlayer = player;
    }

    private void AttackButtonPressed()
    {
        Debug.Log("Attack Button Clicked");

        if (IsTargeting)
        {
            targetingContainer.style.visibility = Visibility.Hidden;
            actionContainer.style.visibility = Visibility.Hidden;
            attachedPlayer.TakeTurn(attachedPlayer.attackAction, currentTarget);
            return;
        }

        currentMode = TurnMode.TargetingPlayer;
        selectedAction = attachedPlayer.attackAction;

        currentTarget = attachedPlayer.GetInitialTarget();
        currentTargetLabel.text = currentTarget.characterName;
        Debug.Log("New Target: " + currentTarget.characterName);

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
            currentTarget = newTarget;
            currentTargetLabel.text = newTarget.characterName;
            Debug.Log("New Target: "+ newTarget.characterName);
        }
    }

    private enum TurnMode
    {
        SelectingAction,
        TargetingPlayer
    }







}
