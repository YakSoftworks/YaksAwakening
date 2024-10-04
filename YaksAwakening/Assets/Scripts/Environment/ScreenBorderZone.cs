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


    private void Start()
    {

        MoveCameraEnumerator = MoveCameraToNewLocation();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            player = collision.GetComponent<PlayerController>();
            player.PauseMovement();

            StartCoroutine(MoveCameraEnumerator);

        }
    }

    private IEnumerator MoveCameraToNewLocation()
    {

        Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        switch (direction)
        {
            case Direction.Up:
                target.y += verticalTravelDistance;
                break;

            case Direction.Right:
                target.x += horizontalTravelDistance;
                break;

            case Direction.Down:
                target.y -= verticalTravelDistance;
                break;

            case Direction.Left:
                target.x -= horizontalTravelDistance;
                break;
        }


        while(transform.position != target)
        {

            Vector3 location = transform.position;

            location = Vector3.MoveTowards(location, target, cameraSpeed*Time.deltaTime);

            transform.position = location;

            yield return null;
        }

        player.ResumeMovement();

        MoveCameraEnumerator = null;

        MoveCameraEnumerator = MoveCameraToNewLocation();

    }

    
}

public enum Direction
{
    Up,
    Right,
    Down,
    Left
}
