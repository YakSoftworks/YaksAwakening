using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBorderZone : MonoBehaviour
{

    //[SerializeField] private int direction;

    [SerializeField] private Direction direction;

    [SerializeField] private float verticalTravelDistance;

    [SerializeField] private float horizontalTravelDistance;

    [SerializeField] private Transform transform;

    [SerializeField] private float cameraSpeed;

    private PlayerController player;

    private IEnumerator MoveCameraEnumerator;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            

            player = collision.GetComponent<PlayerController>();

            Debug.Log($"Player has entered a zone and status is: {player.justMovedScenes}");

            //if (player.justMovedScenes)
            //{
            //    player.justMovedScenes = false;
            //}
            //else
            //{

            //    StartCoroutine(player.MoveCameraAndPlayerToNewLocation(direction));

            //}


            //Check to see if changing rooms is valid
            if (GameManager.Instance.ChangeRoomUsingDirection(direction))
            {
                StartCoroutine(player.MoveCameraAndPlayerToNewLocation(direction));
            }

            

        }
    }

    

    
}

public enum Direction
{
    Up,
    Right,
    Down,
    Left
}
