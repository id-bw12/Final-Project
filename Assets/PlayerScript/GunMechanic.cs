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

public class GunMechanic : MonoBehaviour {
	
	private Camera _camera;
    

	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera>();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	/**********************************************************
	 * 	NAME: 			OnGUI
	 *  DESCRIPTION:	Sets the aiming cursor on the middle 
	 * 					of the screen.
	 * 
	 * ********************************************************/
	void OnGUI(){
		int size = 12;
		float posX = _camera.pixelWidth / 2 - size / 4;
		float posY = _camera.pixelHeight / 2 - size / 4;

		GUI.Label (new Rect (posX, posY, size, size), "*");
	}

	// Update is called once per frame
	void Update () {
		//if (Input.GetMouseButtonDown (0) && Time.timeScale != 0){
		//	var point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
		//	var ray = _camera.ScreenPointToRay (point);
		//	RaycastHit hit;

		//	if (Physics.Raycast (ray, out hit)) {
		//		var hitObject = hit.transform.gameObject;
		//		var target = hitObject.GetComponent<ReactiveTarget> ();

		//		if (target != null) {
		//			target.ReactToHit ();
		//			//Messenger.Broadcast (new GameEvent ().HitMessage);
		//		}
		//		else 
		//			StartCoroutine (SphereIndictor (hit.point));
					
		//	}
				
		//}
	}

	/**********************************************************
	 * 	NAME: 			SphereIndictor
	 *  DESCRIPTION:	Makes the bullet that was fired and give 
	 * 					it the position that was passed. Then wait 
	 * 					.5 seconds and then destroys them.
	 * 
	 * ********************************************************/

	private IEnumerator SphereIndictor(Vector3 pos){
		var sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);

		sphere.transform.position = pos;

		yield return new WaitForSeconds (0.5f);

		Destroy (sphere);
	}
}
