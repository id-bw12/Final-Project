using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;

public class Level1 : BaseControlScript {


    void Awake(){

		level = LevelState.level1;

        Destroy(this.GetComponent<MainScript>());

        this.gameObject.AddComponent<PauseMenu>();


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P)) {
			
			StartCoroutine (ChangeLevel ());

        }

	}

	IEnumerator ChangeLevel(){
	
		float fadeTime = this.gameObject.GetComponent<Fadeout> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		this.gameObject.AddComponent<MainScript>();

		SceneManager.LoadScene ("Main Menu");

		 fadeTime = this.gameObject.GetComponent<Fadeout> ().BeginFade (-1);
		yield return new WaitForSeconds (fadeTime);
	}
}
