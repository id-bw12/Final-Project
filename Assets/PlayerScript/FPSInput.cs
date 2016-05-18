/**********************************************************
***********************************************************
***********************************************************
***														***
***						ID INFORMATION					***
***														***
***	Programmers				  :		  Eddie Meza Jr.	***
***	Assignment #			  :		  Program 4         ***
***	Assignment Name			  :		  GETTING GUI	    ***
*** Course # and Title		  :		  CISC 221			***
*** Class Meeting Time		  :		  TTH 09:35 - 12:45	***
*** Instructor				  :		  Professor Forman	***
*** Hours					  :		  10 				***
*** Difficulty				  :		  5 				***
*** Completion Date			  :		  03/23/2016		***
*** Project Name			  :		  FPS_unity		    ***
***														***
***********************************************************
***********************************************************
***														***
***			Program	Description 						***
***														***
***	  A demo to add a pause menu to the FPS game.	    ***
***   The program has the FPS projects full components. ***
***	  The pause menu can exit the game mode and change  ***
***	  the players and enemy speed.						***
***														***
***********************************************************
***********************************************************
***														***
***					Credits								***
***														***
***		Professor Forman's handout for making it easier ***
***		to compelte the TA.								***
***														***
***														***
***														***
***********************************************************
***********************************************************
***														***					
					Media

***														***
***********************************************************
***********************************************************
**********************************************************/

using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : PlayerCharacter
{

    private float baseSpeed = 6.0f, gravity = -9.0f;
    private CharacterController charController;
    private ControllerColliderHit contact;
    private Vector3 m_GroundNormal;

    // Use this for initialization
    void Start()
    {

        charController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        bool hitGround = false;

        RaycastHit hit;
       
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        var movement = transform.InverseTransformDirection(new Vector3(deltaX, 0, deltaZ));

        movement = Vector3.ProjectOnPlane(movement, m_GroundNormal);

        if (vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit)){
            m_GroundNormal = hit.normal;
            float check = (charController.height + charController.radius) / 9.9f;

            hitGround = hit.distance <= check;
        }

        CheckJumping(hitGround, ref movement);

        movement.y = vertSpeed;

        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        charController.Move(movement);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        contact = hit;

        //this.gameObject.transform.SetParent(hit.transform);

    }

    /****************************************************************
     * 	NAME: 			CheckingJumping
     *  DESCRIPTION:	Passes a boolean and references a Vector3
     * 					variable and checks if the player is grounded
     * 					and 
     * 					then passes it to the game logic and 
     * 					activate to the timer.
     * 
     * ***************************************************************/

    void CheckJumping(bool isGrounded, ref Vector3 movement)
    {

        if (isGrounded)
        {
            Debug.Log("grounded");
            if (Input.GetButton("Jump"))
                vertSpeed = jumpSpeed;
            else
            { 
                vertSpeed = -0.1f;
                m_GroundNormal = Vector3.up;
            }
        }
        else {
            vertSpeed += gravity * 5 * Time.deltaTime;
            Debug.Log("falling");
            if (vertSpeed < terminalVelocity)
                vertSpeed = terminalVelocity;

            if (charController.isGrounded)
            {
                if (Vector3.Dot(movement, contact.normal) < 0)
                    movement = contact.normal * speed;
                else
                    movement += contact.normal * speed;
            }

        }
    }
}



