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

public class playerSight : MonoBehaviour {

	public enum RotationAxes{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2,
		None = 3
	}

	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float rotationX = 0;

	// Use this for initialization
	void Start () {

		Rigidbody body = GetComponent<Rigidbody> ();

		if(body != null)
			body.freezeRotation = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale == 1) {
			if (axes == RotationAxes.MouseX) {

				transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityHor, 0);
			} else if (axes == RotationAxes.MouseY) {
			
				rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
				rotationX = Mathf.Clamp (rotationX, minimumVert, maximumVert);

				float rotationY = transform.localEulerAngles.y;

				transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);
			} else if (axes != RotationAxes.None) {

				rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
				rotationX = Mathf.Clamp (rotationX, minimumVert, maximumVert);

				float delta = Input.GetAxis ("Mouse X") * sensitivityHor;
				float rotationY = transform.localEulerAngles.y + delta;

				transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);
			}

		}
	}
}
