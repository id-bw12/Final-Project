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

public class PlayerCharacter : MonoBehaviour {

	private int health = 5;
    protected float speed = 6.0f, vertSpeed = -1.6f, jumpSpeed = 12.0f, terminalVelocity = -10.0f;

	/**********************************************************
	 * 	NAME: 			GetPlayerHealth
	 *  DESCRIPTION:	returns the players health.
	 * 
	 * ********************************************************/
	public int GetPlayerHealth(){
		return health;
	}

	/**********************************************************
	 * 	NAME: 			hurt
	 *  DESCRIPTION:	Lowers the players health by the value
	 * 					pass to the method.
	 * 
	 * ********************************************************/
	public void Hurt(int damage){
		health -= damage;
	}
}
