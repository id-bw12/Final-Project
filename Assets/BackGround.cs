using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

	GUITexture background;

	// Use this for initialization
	void Start () {
	
		gameObject.GetComponent<GUITexture> ();

		Rect size = new Rect ();

		size.x = (Screen.width / 2);

		size.y = -(Screen.height / 2);

		background = gameObject.GetComponent<GUITexture> ();

		background.pixelInset = size;

	}

	void Update(){
		
		Rect size = new Rect ();

		size.x = (Screen.width / 2);

		size.y = -(Screen.height / 2);

		background = gameObject.GetComponent<GUITexture> ();

		background.pixelInset = size;
	}

}
