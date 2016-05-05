using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainScript : BaseControlScript {

	private UIMakerScript ui = new UIMakerScript();

	private GameObject canvas, panel, eventSystem;

	// Use this for initialization
	void Start () {
		canvas = ui.CreateCanvas (this.transform);

		eventSystem = ui.CreateEventSystem (canvas.transform);

		state = MainStates.Main;

		CheckMenuState ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void CheckMenuState(){

		switch (state) {

		case MainStates.Main:
			MakeMainScreen (0, 4);
			break;

		case MainStates.Credits:
			MakeMainScreen (1,5);
			break;

		case MainStates.Options:
			break;

		case MainStates.Exit:
			break;
		}

	}
	/*********************************************************
	 * 
	 * 
	 * 
	 * 
	 * ******************************************************/
	void MakeMainScreen(int row, int columnLimit){
		List<List<Vector2>> positions = new List<List<Vector2>> () {
			new List<Vector2> (){ new Vector2(0f,30f), new Vector2(0,0), new Vector2(0,-30), new Vector2(0,-60)}, 
			new List<Vector2> (){ new Vector2(-100f,-60f), new Vector2(0,-60f), new Vector2(100,-60f), new Vector2(0,-60f), new Vector2(0,60f)},
			new List<Vector2>(){ new Vector2 (2, 2) },
		};

		List<List<string>> buttonNames = new List<List<string>> () {
			new List<string> (){ "Play", "Credits", "Options", "Exit" },
			new List<string> (){ "Id Info", "Credits", "Media", "Stars", "Back" },
			new List<string> (){ "Back" },
		};

		string buttonName;

		panel = ui.CreatePanel (canvas.transform, Color.clear);

		for (int i = 0; i < columnLimit; i++) {

			buttonName = buttonNames [row] [i];

			ui.CreateButton (panel.transform, positions [row] [i], new Vector2 (100, 30), 
				buttonNames[row][i], buttonNames[row][i], 
				delegate {ChangeMenuStates ();});
		}

	}

	void ChangeMenuStates(){

		string name = eventSystem.GetComponent<EventSystem> ().currentSelectedGameObject.name;

		switch (name) {
		case "Play":
			break;

		case "Options":
			state = MainStates.Options;
			break;

		case "Credits":
			state = MainStates.Credits;
			break;

		case "Exit":
			state = MainStates.Exit;
			break;

		case "Back":
			state = MainStates.Main;
			break;
		}

		GameObject.Destroy (panel);

		CheckMenuState ();

	}
}
