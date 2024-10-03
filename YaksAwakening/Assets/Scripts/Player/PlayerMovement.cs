using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //private CharacterController controller;

    [SerializeField] private Rigidbody2D rigidbody;

    private Vector2 movementInput;

    [SerializeField] private float moveSpeed;

    private void Start()
    {
        //controller = GetComponent<CharacterController>();

        //controller.enabled = true;
    }

    public void SetMovement(Vector2 input)
    {
        movementInput = input;
    }

    private void FixedUpdate()
    {

        MoveCharacter();

    }

    private void MoveCharacter()
    {
        Vector2 movement = new Vector2();
        if (Mathf.Abs(movementInput.x) > 0.01f)
        {

            Debug.Log("Character Trying to move in the X");
            movement += new Vector2(movementInput.x * moveSpeed, 0f);
            //controller.Move(movement);
            //rigidbody.MovePosition(rigidbody.position+movement);

        }

        if (Mathf.Abs(movementInput.y) > 0.01f)
        {

            Debug.Log("Character Trying to move in the Y");

            movement += new Vector2(0f, movementInput.y * moveSpeed);
            //rigidbody.MovePosition(rigidbody.position + movement);

            //controller.Move(movement);


        }

        rigidbody.MovePosition(rigidbody.position + movement);


    }



}