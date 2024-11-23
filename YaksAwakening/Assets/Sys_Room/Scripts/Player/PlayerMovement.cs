using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //private CharacterController controller;

    [SerializeField] private Rigidbody2D rigidbody;

    [SerializeField] private Animator animator;

    private Vector2 movementInput;

    [SerializeField] private float moveSpeed;

    private int direction;

    private void Start()
    {

        direction = 0;
    }

    public void SetMovement(Vector2 input)
    {
        movementInput = input;
    }

    private void Update()
    {

        direction = DecideFacingDirection();

        animator.SetInteger("direction", direction);


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

            //Debug.Log("Character Trying to move in the X");
            movement += new Vector2(movementInput.x * moveSpeed, 0f);


        }

        if (Mathf.Abs(movementInput.y) > 0.01f)
        {

            //Debug.Log("Character Trying to move in the Y");

            movement += new Vector2(0f, movementInput.y * moveSpeed);


        }

        movement = movement * Time.deltaTime;

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("isMoving", true);
        }

        else
        {
            animator.SetBool("isMoving", false);
        }


        rigidbody.MovePosition(rigidbody.position + movement);


    }

    private int DecideFacingDirection()
    {

        //Debug.Log(movementInput.ToString());

        if(movementInput.x == movementInput.y)
        {
            return direction;
        }

        //Decide primary direction

        else if(Mathf.Abs(movementInput.x) > Mathf.Abs(movementInput.y))
        {
            //Face in the X direction

            if(movementInput.x > 0)
            {
                //Debug.Log("Facing North");
                return 1;
                
            }
            else
            {
                //Debug.Log("Facing South");
                return 3;
            }

        }

        else
        {
            //Face in the Y direction

            if (movementInput.y > 0)
            {

                //Debug.Log("Facing Right");
                return 0;

            }

            else
            {
                //Debug.Log("Facing Left");
                return 2;
            }

        }

    }


    

}