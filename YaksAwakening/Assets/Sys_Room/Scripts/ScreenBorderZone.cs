using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBorderZone : MonoBehaviour
{
    //Side of the screen this trigger is on
    [SerializeField] private Direction direction;

    private PlayerController player;

    //When something enters the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If it is the player
        if (collision.CompareTag("Player"))
        {
            

            player = collision.GetComponent<PlayerController>();

            Debug.Log($"Player has entered a zone and status is: {player.justMovedScenes}");


            //Check to see if changing rooms is valid
            if (GameManager.Instance.ChangeRoomUsingDirection(direction))
            {
                //Tell they player they may change rooms
                StartCoroutine(player.MoveCameraAndPlayerToNewLocation(direction));
            }

            

        }
    }

    

    
}

//Enum for determining direction of room movement
public enum Direction
{
    Up,
    Right,
    Down,
    Left
}
