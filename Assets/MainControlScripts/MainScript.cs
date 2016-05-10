using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;
using System.Collections.Generic;

using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainScript : BaseControlScript {

	private UIMakerScript ui = new UIMakerScript();

    bool faded = false;
    
	// Use this for initialization
	void Start () {
		canvas = ui.CreateCanvas (this.transform);

        canvas.gameObject.AddComponent<CanvasGroup>();

		eventSystem = ui.CreateEventSystem (canvas.transform);

		state = MainStates.Main;

        CheckMenuLocation();
	}

    /*********************************************************
	 * 
	 * Name:        CheckMenuLocation
	 * 
	 * Description: Check the current state of the menu and
     *              selects the correct method with the right
     *              variables so the correct object can be made.
     *
     *******************************************************/
    void CheckMenuLocation(){

        switch (state)
        {

            case MainStates.Play:
                TransferScene();
                break;

            case MainStates.Credits:
                MakeMainScreen(1, 5);
                break;

            case MainStates.Options:
                MakeMainScreen(2, 1);
                break;

            case MainStates.Exit:
                break;

            case MainStates.Main:
                MakeMainScreen(0, 4); //The zero is the row in the 2D list and the 4 is the size of the column in the 2D list
                break;
        }

    }

	/*********************************************************
	 * 
	 * Name:        MakeMainScreen
	 * 
	 * Description: Makes two int variables that are used for
     *              the 2D lists and makes the menu screen.
     *
     *
	 * ******************************************************/
    void MakeMainScreen(int row, int columnLimit){
		List<List<Vector2>> positions = new List<List<Vector2>> () {
			new List<Vector2> (){ new Vector2(0f,30f), new Vector2(0,10), new Vector2(0,-10), new Vector2(0,-30)}, 
			new List<Vector2> (){ new Vector2(-110f,-90f), new Vector2(-53,-90f), new Vector2(04,-90f), new Vector2(61,-90f), new Vector2(118,-90f)},
			new List<Vector2>(){ new Vector2 (-85, -90) },
		};

		List<List<string>> buttonNames = new List<List<string>> () {
			new List<string> (){ "Play", "Credits", "Options", "Exit" },
			new List<string> (){ "Id Info", "Credits", "Media", "Stars", "Back" },
			new List<string> (){ "Back" },
		};

		panel = ui.CreatePanel (canvas.transform, Color.clear);

        for (int i = 0; i < columnLimit; i++)
        {
          var button = ui.CreateButton(panel.transform, positions[row][i], new Vector2(75, 25),
                buttonNames[row][i], buttonNames[row][i],
                delegate { StartCoroutine (ChangeMenuStates()); });

            button.GetComponent<RectTransform>().localScale = new Vector3(0.75f, 0.75f, 1.0f);
        }

        if (MainStates.Options == state){
            ui.CreateScaler(panel.transform, new Vector2(25, 100), 100);
        }

        if (faded)
            this.gameObject.GetComponent<MenuAnimation>().FadeAnimation(faded = false);
        

	}

	IEnumerator ChangeMenuStates(){

        //get the button that was clicked
		var name = eventSystem.GetComponent<EventSystem> ().currentSelectedGameObject.name;

        switch (name)
        {
            case "Play":
                state = MainStates.Play;
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

        this.gameObject.GetComponent<MenuAnimation>().FadeAnimation(faded = true);

        yield return new WaitForSeconds(1.5f);

        GameObject.Destroy (panel);

        CheckMenuLocation();

	}

    void TransferScene() {

        SceneManager.LoadScene("Level 1");
    }
}
