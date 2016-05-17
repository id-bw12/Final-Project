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


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : PlayerCharacter {

	private float baseSpeed = 6.0f,gravity  = -9.8f ;
	private CharacterController charController;

	// Use this for initialization
	void Start () {
		
		charController = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;

		var movement = new Vector3 (deltaX, 0, deltaZ);

		movement = Vector3.ClampMagnitude (movement, speed);
		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);

		charController.Move (movement);
	}

	/**********************************************************
	 * 	NAME: 			Speed
	 *  DESCRIPTION:	gets or sets the players speed variable.
	 * 
	 * ********************************************************/
	public float Speed{

		get{ return speed;}
		set{ speed = value;}
	}

	/**********************************************************
	 * 	NAME: 			Speed
	 *  DESCRIPTION:	gets or sets the players speed variable.
	 * 
	 * ********************************************************/
	public void Awake(){
		//Messenger<float>.AddListener (new GameEvent ().SpeedMessage, OnSpeedChanged);
	}

	/**********************************************************
	 * 	NAME: 			Speed
	 *  DESCRIPTION:	gets or sets the players movement speed 
	 * 					variable.
	 * 
	 * ********************************************************/
	public void OnDestory(){
		//Messenger<float>.AddListener (new GameEvent ().SpeedMessage, OnSpeedChanged);
	}

	/**********************************************************
	 * 	NAME: 			OnSpeedChanged
	 *  DESCRIPTION:	Changes the player's movement speed by
	 * 					multipling the base speed by the value 
	 * 					given.
	 * 
	 * ********************************************************/
	private void OnSpeedChanged(float value){

		speed = baseSpeed * value;

	}
}
