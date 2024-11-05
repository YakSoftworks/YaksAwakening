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

    private DropdownMenu enemyMenu;

    private TempPlayer attachedPlayer;

    private BattleAction selectedAction;

    private void Start()
    {

        rootElement = ui.rootVisualElement;


        attackButton = rootElement.Q<Button>("AttackButton");
        waitButton = rootElement.Q<Button>("WaitButton");

        actionContainer = rootElement.Q<VisualElement>("ActionContainer");



        //rootElement.style.visibility = Visibility.Hidden;

        attackButton.clicked += AttackButtonPressed;

        waitButton.clicked += WaitButtonPressed;

        actionContainer.style.visibility = Visibility.Hidden;
        

    }

    private void OnDestroy()
    {
        attackButton.clicked -= AttackButtonPressed;

        waitButton.clicked -= WaitButtonPressed;
    }

    public void PromptPlayerAction(TempPlayer player)
    {
        //Reset internal variables
        Debug.Log("PromptMenu showing");

        actionContainer.style.visibility = Visibility.Visible;
        attachedPlayer = player;
    }

    private void AttackButtonPressed()
    {
        Debug.Log("Attack Button Clicked");
        selectedAction = attachedPlayer.attackAction;
        actionContainer.style.visibility = Visibility.Hidden;
        attachedPlayer.TakeTurn(attachedPlayer.attackAction, attachedPlayer.GetRandomTarget());

        
    }

    private void WaitButtonPressed()
    {
        Debug.Log("Wait Button Clicked");
        //Tell the player to take a wait action
        actionContainer.style.visibility = Visibility.Hidden;
        attachedPlayer.TakeTurn(attachedPlayer.waitAction, null);
        
    }







}
