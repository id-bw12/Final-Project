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
using UnityEngine.UI;
using System.IO;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using System.Collections;

public class UIMakerScript : MonoBehaviour {

	//http://chikkooos.blogspot.com/2015/03/new-ui-implementation-using-c-scripts.html

	private const int LayerUI = 5;

	/**********************************************************
	 * 	NAME: 			CreateCanvas
	 *  DESCRIPTION:	Get the control object transform and 
	 * 					uses it to create to the canvas and 
	 * 					return it.
	 * 
	 * ********************************************************/

	public GameObject CreateCanvas(Transform parent)
	{
		// create the canvas
		GameObject canvasObject = new GameObject("Canvas");
		canvasObject.layer = LayerUI;

		canvasObject.AddComponent<RectTransform>().localScale = new Vector3(1.0f,2.0f,1.0f);

		Canvas canvas = canvasObject.AddComponent<Canvas>();
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		canvas.pixelPerfect = true;

		CanvasScaler canvasScal = canvasObject.AddComponent<CanvasScaler>();
		canvasScal.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		canvasScal.referenceResolution = new Vector2(300, 200);

		canvasObject.AddComponent<GraphicRaycaster>();

		canvasObject.transform.SetParent(parent);

		return canvasObject;
	}

	/**********************************************************
	 * 	NAME: 			CreateEventSystem
	 *  DESCRIPTION:	Gets the transform of the canvas and 
	 * 					makes the event system and returns it
	 * 
	 * ********************************************************/
	public GameObject CreateEventSystem(Transform parent)
	{
		GameObject esObject = new GameObject("EventSystem");

		EventSystem esClass = esObject.AddComponent<EventSystem>();
		esClass.sendNavigationEvents = true;
		esClass.pixelDragThreshold = 5;

		StandaloneInputModule stdInput = esObject.AddComponent<StandaloneInputModule>();
		stdInput.horizontalAxis = "Horizontal";
		stdInput.verticalAxis = "Vertical";

		esObject.transform.SetParent(parent);

		return esObject;
	}

	/**********************************************************
	 * 	NAME: 			CreatePanel
	 *  DESCRIPTION:	Gets the canvas transform and uses it
	 * 					to make the panel and returns it
	 * 
	 * ********************************************************/
	public GameObject CreatePanel(Transform parent, Color background)
	{
		GameObject panelObject = new GameObject("Panel");
		panelObject.transform.SetParent(parent);

		panelObject.layer = LayerUI;

		RectTransform trans = panelObject.AddComponent<RectTransform>();
		trans.anchorMin = new Vector2(0, 0);
		trans.anchorMax = new Vector2(1, 1);
		trans.anchoredPosition = new Vector2(0, 0);
		trans.offsetMin = new Vector2(0, 0);
		trans.offsetMax = new Vector2(0, 0);
		trans.localPosition = new Vector3(0, 0, 0);
		trans.sizeDelta = new Vector2(0, 0);
		trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);

		panelObject.AddComponent<CanvasRenderer>();

		Image image = panelObject.AddComponent<Image>();

		image.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");

		image.type = Image.Type.Sliced;

		image.color = background;

		return panelObject;
	}


	/************************************************************
	 * 	NAME: 			CreateText
	 *  DESCRIPTION:	Gets the panels transform, x, y, height,
	 * 					width, string, and fontsize variables.
	 * 					Uses it to make the text and returns it.
	 * 
	 * **********************************************************/
	public GameObject CreateText(Transform parent,Vector2 position, Vector2 size, string objectName,
		string message, int fontSize) {

        GameObject textObject = new GameObject(objectName);
        textObject.transform.SetParent(parent);

        textObject.layer = LayerUI;

        RectTransform trans = textObject.AddComponent<RectTransform>();
		trans.sizeDelta = size;
        trans.anchoredPosition3D = new Vector3(0, 0, 0);
		trans.anchoredPosition = position;
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		trans.localPosition.Set (0, 0, 0);

		textObject.AddComponent<CanvasRenderer>();
        
        Text text = textObject.AddComponent<Text>();
        text.supportRichText = true;
        text.text = message;
        text.fontSize = fontSize;
        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.alignment = TextAnchor.MiddleCenter;
        text.horizontalOverflow = HorizontalWrapMode.Overflow;
        text.color = new Color(0, 0, 1);

        return textObject;
    }
    
	/**************************************************************
	 * 	NAME: 			CreatButton
	 *  DESCRIPTION:	Gets the panels transform, x, y, height,
	 * 					width, string, and eventlistner variables.
	 * 					Uses it to make a button and sends the
	 * 					string and the buttons transform to the
	 * 					text for the buttton.
	 * 
	 * ************************************************************/
	public GameObject CreateButton(Transform parent, Vector2 position, Vector2 size, string objectName, 
		string message, UnityAction eventListner) {

		GameObject buttonObject = new GameObject(objectName);

        buttonObject.transform.SetParent(parent);

        buttonObject.layer = LayerUI;

        RectTransform trans = buttonObject.AddComponent<RectTransform>();
        SetSize(trans, size);
        trans.anchoredPosition3D = new Vector3(0, 0, 0);
		trans.anchoredPosition = position;
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        trans.localPosition.Set(0, 0, 0);

        buttonObject.AddComponent<CanvasRenderer>();

        Image image = buttonObject.AddComponent<Image>();

		image.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite> ("UI/Skin/UISprite.psd");

		image.type = Image.Type.Sliced;

        Button button = buttonObject.AddComponent<Button>();
        button.interactable = true;
        button.onClick.AddListener(eventListner);

		CreateText(buttonObject.transform, new Vector2(0,0), size, "buttonText",
                                                   message, 16);

        return buttonObject;
    }

	/**********************************************************
	 * 	NAME: 			CreateScalar
	 *  DESCRIPTION:	Get the panels transform, position, and 
	 * 					float value and uses it to create to the 
	 *					scalar. Also calls the 5 different methods
	 * 					and sends the differnt objects transform
	 * 					to set then in a hierarchy and returns
	 * 					the scalar.
	 * 
	 * ********************************************************/

	public GameObject CreateScaler(Transform parent, Vector2 position, float value, float maxValue){
	
		GameObject scalerObject = new GameObject ("Slider");

		var background = MakeSliderBackground(scalerObject.transform);
        var fillArea = MakeFillArea(scalerObject.transform);
        var fill = MakeFill(fillArea.transform);
        var slideArea = MakeHandleSlideArea(scalerObject.transform);
        var handle = MakeHandle(slideArea.transform);

        scalerObject.transform.SetParent (parent);

		scalerObject.layer = LayerUI;

		RectTransform rect = scalerObject.AddComponent<RectTransform> ();
        rect.anchoredPosition = position;
        rect.sizeDelta = new Vector2(160,20);
        rect.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Image handleImage = handle.GetComponent<Image>();

        Slider slider = scalerObject.AddComponent<Slider> ();

        slider.fillRect = fill.GetComponentInChildren<RectTransform>();
        slider.handleRect = handle.GetComponent<RectTransform>();
        slider.targetGraphic = handleImage;
        slider.direction = Slider.Direction.LeftToRight;
		slider.maxValue = maxValue;
		slider.wholeNumbers = true;
		slider.value = value;

		return scalerObject;
	}

	/**********************************************************
	 * 	NAME: 			MakeSliderBackground
	 *  DESCRIPTION:	Get the slider's transformer and sets the
	 * 					slider background a child of the slider.
	 *					Makes the background and then returns it.
	 * 					the scalar.
	 * 
	 * ********************************************************/
	private GameObject MakeSliderBackground(Transform parent){

		GameObject scalerBackground = new GameObject ("Background");

		scalerBackground.transform.SetParent (parent);

        scalerBackground.layer = LayerUI;

		RectTransform trans = scalerBackground.AddComponent<RectTransform> ();

        trans.anchoredPosition = new Vector3(0.0f, 0.0f);
        trans.sizeDelta = new Vector2(0.0f, 0.0f);
		trans.anchorMin = new Vector2 (0.0f,0.25f);
		trans.anchorMax = new Vector2 (1.0f,0.75f);
		trans.pivot = new Vector2 (0.5f,0.5f);
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        scalerBackground.AddComponent<CanvasRenderer> ();

		Image image = scalerBackground.AddComponent<Image> ();

		image.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");

        image.type = Image.Type.Sliced;

        return scalerBackground;
	}

	/**********************************************************
	 * 	NAME: 			MakeFillArea
	 *  DESCRIPTION:	Get the slider's transformer and sets the 
	 * 					Fill Area as a child of the slider. 
	 * 					Then make the area object and returns
	 * 					it.
	 * 
	 * ********************************************************/
    private GameObject MakeFillArea(Transform parent) {

        GameObject areaObject = new GameObject("Fill Area");

        areaObject.transform.SetParent(parent);

        areaObject.layer = LayerUI;

        RectTransform trans = areaObject.AddComponent<RectTransform>();
        trans.offsetMin = new Vector2(5, 0);
        trans.offsetMax = new Vector2(-15, 0);

        trans.anchorMin = new Vector2(0.0f, 0.25f);
        trans.anchorMax = new Vector2(1.0f, 0.75f);
        trans.pivot = new Vector2(0.5f, 0.5f);

        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        return areaObject;

    }

	/**********************************************************
	 * 	NAME: 			MakeFill
	 *  DESCRIPTION:	Get the MakeFillArea transform and set
	 * 					Fill Object as a child of Fill Area. 
	 * 					Then makes the fill object and set the
	 * 					UISprite sprite to the fill object.
	 * 					Then returns the Fill Object.
	 * 
	 * ********************************************************/
    private GameObject MakeFill(Transform parent) {

        GameObject fillObject = new GameObject("Fill");

        fillObject.transform.SetParent(parent);

        fillObject.layer = LayerUI;

        var trans = fillObject.AddComponent<RectTransform>();

        trans.localPosition = new Vector2(0.0f,0.0f);
        trans.sizeDelta = new Vector2(10, 0);
        trans.anchorMin = new Vector2(0.0f, 0.0f);
        trans.anchorMax = new Vector2(0.0f, 1.0f);
        trans.pivot = new Vector2(0.5f, 0.5f);
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        fillObject.AddComponent<CanvasRenderer>();

        var image = fillObject.AddComponent<Image>();

        image.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");

        image.type = Image.Type.Sliced;

        return fillObject;

    }

	/**********************************************************
	 * 	NAME: 			MakeHandleSlideArea
	 *  DESCRIPTION:	Get the slider's transformer and sets the 
	 * 					handle slide area object as a child of the
	 *					scalar. Makes Handle Slide Area and returns
	 * 					its.
	 * 
	 * ********************************************************/
    private GameObject MakeHandleSlideArea(Transform parent) {

        GameObject slideArea = new GameObject("Handle Slide Area");

        slideArea.transform.SetParent(parent);

        slideArea.layer = LayerUI;

        RectTransform trans = slideArea.AddComponent<RectTransform>();

        trans.offsetMin = new Vector2(10, 0);
        trans.offsetMax = new Vector2(-10, 0);
        trans.anchorMin = new Vector2(0.0f, 0.0f);
        trans.anchorMax = new Vector2(1.0f, 1.0f);
        trans.pivot = new Vector2(0.5f, 0.5f);
        trans.localScale = new Vector3(1.0f, 1.0f,1.0f);

        return slideArea;
    }

	/**********************************************************
	 * 	NAME: 			MakeHandle
	 *  DESCRIPTION:	Get the handle slide area transform 
	 * 					and sets the handle object as a child of 
	 *					handle slide area. Then makes the handle 
	 * 					that move on the slider to change the 
	 * 					value.
	 * 
	 * ********************************************************/
    private GameObject MakeHandle(Transform parent) {

        GameObject handleObject = new GameObject("Handle");

        handleObject.transform.parent = parent;

        handleObject.layer = LayerUI;

        var trans = handleObject.AddComponent<RectTransform>();

        trans.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
        trans.sizeDelta = new Vector2(20,0);
        trans.anchorMin = new Vector2(0.0f, 0.0f);
        trans.anchorMax = new Vector2(0.0f, 1.0f);
        trans.pivot = new Vector2(0.5f, 0.5f);
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        handleObject.AddComponent<CanvasRenderer>();

        var image = handleObject.AddComponent<Image>();

        image.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Knob.psd");

        image.type = Image.Type.Simple;

        return handleObject;
    }

	/**********************************************************
	 * 	NAME: 			SetSize
	 *  DESCRIPTION:	Gets the buttons tansform and its width
	 * 					and height and uses it to set the button
	 * 					offset position.
	 * 
	 * ********************************************************/

    private static void SetSize(RectTransform trans, Vector2 size) {
        Vector2 currSize = trans.rect.size;
        Vector2 sizeDiff = size - currSize;
        trans.offsetMin = trans.offsetMin -
                                  new Vector2(sizeDiff.x * trans.pivot.x,
                                      sizeDiff.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax + 
                                  new Vector2(sizeDiff.x * (1.0f - trans.pivot.x),
                                      sizeDiff.y * (1.0f - trans.pivot.y));
    }
}
