using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using UnityEditor;

using System.Collections;
using System.Collections.Generic;


public class MainScript : BaseControlScript
{

    private UIMakerScript ui = new UIMakerScript();

    bool faded = false;

    // Use this for initialization
    void Start()
    {
        canvas = ui.CreateCanvas(this.transform);

        canvas.gameObject.AddComponent<CanvasGroup>();

        eventSystem = ui.CreateEventSystem(canvas.transform);


		if (MenuStates.None == state) {
			state = MenuStates.SplashScreen;
			CheckMenuLocation ();
		}else if (MenuStates.Play == state){
			Debug.Log ("Success");
			state = MenuStates.Main;
			CheckMenuLocation ();
		} else if (state == MenuStates.Exit) {
			MakeMainScreen (4);
		}
           
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
    void CheckMenuLocation()
    {

        switch (state)
        {

		case MenuStates.SplashScreen:
				MakeMainScreen (0); // the number is the row for the 2D list
				break;

            case MenuStates.Play:
                TransferScene();
                break;

			case MenuStates.Main:
				MakeMainScreen(1); //The zero is the row in the 2D list and the 4 is the size of the column in the 2D list
				break;

			case MenuStates.instructions:
				MakeMainScreen (2);
				break;

            case MenuStates.Credits:
                MakeMainScreen(3);
                break;

            case MenuStates.Options:
                MakeMainScreen(4);
                break;

			case MenuStates.Exit:
				MakeMainScreen (5);
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
    void MakeMainScreen(int row){

        panel = ui.CreatePanel(canvas.transform, Color.clear);

        MakeButtons(row);

		if (state == MenuStates.instructions)
			MakeText (1);
		else if (state == MenuStates.SplashScreen)
			MakeText (0);

        if (MenuStates.Options == state)
            MakeSlider();
        
        if (faded)
            this.gameObject.GetComponent<MenuAnimation>().FadeAnimation(faded = false);


    }

    void MakeButtons(int row) {

        List<List<Vector2>> buttonPositions = new List<List<Vector2>>() {
			new List<Vector2> (){ new Vector2 (0,-50)},
			new List<Vector2> (){ new Vector2 (0f,30f), new Vector2(0,10), new Vector2(0,-10), new Vector2(0,-30), new Vector2(0,-50)},
            new List<Vector2> (){ new Vector2 (-110f,-90f), new Vector2(-53,-90f), new Vector2(04,-90f), new Vector2(61,-90f), new Vector2(118,-90f)},
            new List<Vector2> (){ new Vector2 (0, -70) },
			new List<Vector2> (){ new Vector2 (0, -50)},
			new List<Vector2> (){ new Vector2 (0, -60)}
        };

        List<List<string>> buttonNames = new List<List<string>>() {
			new List<string> (){ "Welcome"}, //Splash screen
            new List<string> (){ "Play", "Instruction", "Credits", "Options", "Exit" }, //menu screen
			new List<string> (){ "Back"}, //Instruction screen
            new List<string> (){ "Id Info", "Credits", "Media", "Stars", "Back" }, //id info screen
            new List<string> (){ "Back" }, //options screen
			new List<string> (){ "Good Bye"} // Exit screen
        };

        for (int i = 0; i < buttonNames[row].Count; i++)
        {
            var button = ui.CreateButton(panel.transform, buttonPositions[row][i], new Vector2(75, 25),
                  buttonNames[row][i], buttonNames[row][i],
                  delegate { StartCoroutine(ChangeMenuStates()); });

            button.GetComponent<RectTransform>().localScale = new Vector3(0.75f, 0.75f, 1.0f);
        }
    }

	//This shows the texts. Row 0 is the splash screen, row 1 is the instruction screen and row 3 is the Exit screen.
	void MakeText(int row){
		List<List<string>> textObject = new List<List<string>> () {
			new List<string>(){"","Journey for Quez-Natl"},
			new List<string>(){"You move by using the arrow or the ASDW keys and look around by using the mouse.\n\n"+
				"You earn point by collecting jewels. Get 100 points and get a 1 life and you lose one\n"+
				"falling in to a pit or getting hit by an enemy. You start off with three lives.\n\n"+
				"To advance to the next level hit the N key.", "Instructions"},
			new List<string>(){"",""}
		};

		List<Vector2> textPositions = new List<Vector2>() { new Vector2 (0,50),new Vector2(0,25), new Vector2(0,0)};


		var headerText = ui.CreateText (panel.transform, new Vector2 (0, 70), new Vector2 (50, 25), "Title header", textObject [row] [1], 15);
		headerText.GetComponent<Text> ().color = Color.black;
		headerText.transform.localScale = new Vector3(0.75f,1.0f,0.75f);
		

		var text =  ui.CreateText(panel.transform, textPositions[row], new Vector2(50, 75), "TextBody", textObject[row][0], 15);

		text.GetComponent<Text> ().color = Color.black;
		if (row != 0) {
			text.transform.localScale = new Vector3 (0.75f, 1.0f, 0.75f);
			text.GetComponent<Text> ().fontSize = 10;
		}
	}

    void MakeSlider() {

        List<List<string>> labels = new List<List<string>>() {
            new List<string>(){ "Music Volume", "Sound Volume" },
            new List<string>(){ "Music Slider","Sound Slider"}
        };

        List<List<Vector2>> positions = new List<List<Vector2>>(){
            new List<Vector2>() { new Vector2(10, 100), new Vector2(10, 50) },
            new List<Vector2>() { new Vector2(10, 80), new Vector2(10, 30)}
        };

        float[] volume = new float[] {(this.gameObject.GetComponent<AudioSource>().volume*100), 100 };

        for (int i = 0; i < labels.Count; i++)
        {
            var text = ui.CreateText(panel.transform, positions[0][i], new Vector2(50, 50), labels[0][i], labels[0][i], 12);
            text.GetComponent<Text>().color = Color.black;
            text.transform.localScale = new Vector3( 0.75f, 0.75f , 1.0f);

            var scale = ui.CreateScaler(panel.transform, positions[1][i], volume[i], 100);
            scale.transform.localScale = new Vector3(0.75f, 0.75f, 1.0f);
            scale.name = labels[1][i];
            scale.GetComponent<Slider>().onValueChanged.AddListener(delegate { ChangeAudio(); });
        }
    }

    IEnumerator ChangeMenuStates()
    {

        //get the button that was clicked
        var name = eventSystem.GetComponent<EventSystem>().currentSelectedGameObject.name;

        switch (name)
        {
			case "Welcome":
				state = MenuStates.Main;
				break;

            case "Play":
                state = MenuStates.Play;
                break;

			case "Instruction":
				state = MenuStates.instructions;
				break;

            case "Options":
                state = MenuStates.Options;
                break;

            case "Credits":
                state = MenuStates.Credits;
                break;

            case "Exit":
                state = MenuStates.Exit;
                break;

            case "Back":
                state = MenuStates.Main;
                break;

			case "Good Bye":
				Exit ();
				break;
        }

        this.gameObject.GetComponent<MenuAnimation>().FadeAnimation(faded = true);

        yield return new WaitForSeconds(1.5f);

        GameObject.Destroy(panel);

        CheckMenuLocation();

    }

    void TransferScene()
    {
        GameObject.Destroy(canvas);

		SceneManager.LoadScene ("Level 1");

		this.gameObject.AddComponent<Level1>();
    }

    void Exit()
    {

        UnityEditor.EditorApplication.isPlaying = false;
    }

    void ChangeAudio() {

        var scaler = eventSystem.GetComponent<EventSystem>().currentSelectedGameObject;

        switch (scaler.name) {

            case "Music Slider":
                musicVolume = (scaler.GetComponent<Slider>().value / 100);
                this.GetComponent<AudioSource>().volume = musicVolume;
                break;

            case "Sound Volume": 
                soundEffectVolume = (scaler.GetComponent<Slider>().value / 100);
                break;
        }

        Debug.Log(scaler.GetComponent<Slider>().value);
    }
}
