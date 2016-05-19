using UnityEngine;
using System.Collections;

public class Fadeout : MonoBehaviour {
	//Debug.Log (level);
	public Texture2D fadeTexture = Resources.Load("1") as Texture2D;
	public float fadeSpeed = 0.8f; 
	public float alpha = 1.0f;
	public int drawDepth = -1000, fadeDir = -1;

	//The code to start the fadeout and fade in is in Level 1 script

	void OnGUI(){
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r,GUI.color.g,GUI.color.b,alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height), fadeTexture);
	
	}
	
	public float BeginFade(int direction){
		fadeDir = direction;
		return fadeSpeed;
	}

	void OnLevelWasLoad(){
		BeginFade (-1);
	}
}
