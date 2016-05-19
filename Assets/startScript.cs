using UnityEngine;
using System.Collections;

public class startScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!GameObject.Find ("Control")) {
			var control = new GameObject ();

			control.name = "Control";

			control.AddComponent<MainScript> ();
			control.AddComponent<MenuAnimation> ();
			//control.AddComponent<AudioScript> ();
			control.AddComponent<AudioSource> ();
			control.AddComponent<ObjectTransfer> ();
			control.AddComponent<Fadeout> ();
		}
	}

}
