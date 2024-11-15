using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{


    [SerializeField] private float moveSpeed = 0.05f;

    private float distanceThreshold = 0.01f;

    private Vector2 destination;

    [SerializeField] private float moveDistance = 5f;

    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed*Time.deltaTime);

        if(Vector2.Distance(transform.position, destination) < distanceThreshold)
        {
            //Pick new destination
            Vector2 currentLocation = transform.position;

            destination = currentLocation + (Random.insideUnitCircle * moveDistance);

        }


    }





}
