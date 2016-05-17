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

        if(MenuStates.None == state || MenuStates.Play == state)
            state = MenuStates.Main;

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
    void CheckMenuLocation()
    {

        switch (state)
        {

            case MenuStates.Play:
                TransferScene();
                break;

            case MenuStates.Credits:
                MakeMainScreen(1);
                break;

            case MenuStates.Options:
                MakeMainScreen(2);
                break;

            case MenuStates.Exit:
                Exit();
                break;

            case MenuStates.Main:
                MakeMainScreen(0); //The zero is the row in the 2D list and the 4 is the size of the column in the 2D list
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

        if (MenuStates.Options == state)
            MakeSlider();
        
        if (faded)
            this.gameObject.GetComponent<MenuAnimation>().FadeAnimation(faded = false);


    }

    void MakeButtons(int row) {

        List<List<Vector2>> buttonPositions = new List<List<Vector2>>() {
            new List<Vector2> (){ new Vector2(0f,30f), new Vector2(0,10), new Vector2(0,-10), new Vector2(0,-30)},
            new List<Vector2> (){ new Vector2(-110f,-90f), new Vector2(-53,-90f), new Vector2(04,-90f), new Vector2(61,-90f), new Vector2(118,-90f)},
            new List<Vector2> (){ new Vector2 (-85, -90) },
        };

        List<List<string>> buttonNames = new List<List<string>>() {
            new List<string> (){ "Play", "Credits", "Options", "Exit" },
            new List<string> (){ "Id Info", "Credits", "Media", "Stars", "Back" },
            new List<string> (){ "Back" },
        };

        for (int i = 0; i < buttonNames[row].Count; i++)
        {
            var button = ui.CreateButton(panel.transform, buttonPositions[row][i], new Vector2(75, 25),
                  buttonNames[row][i], buttonNames[row][i],
                  delegate { StartCoroutine(ChangeMenuStates()); });

            button.GetComponent<RectTransform>().localScale = new Vector3(0.75f, 0.75f, 1.0f);
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
            case "Play":
                state = MenuStates.Play;
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
        }

        this.gameObject.GetComponent<MenuAnimation>().FadeAnimation(faded = true);

        yield return new WaitForSeconds(1.5f);

        GameObject.Destroy(panel);

        CheckMenuLocation();

    }

    void TransferScene()
    {
        GameObject.Destroy(canvas);

        SceneManager.LoadScene("Level 1");
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
