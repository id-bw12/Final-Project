using UnityEngine;
using System.Collections;

public class AudioScript : BaseControlScript {

	AudioSource audio;

	LevelState savedLevel;

	void Start(){
		audio = gameObject.GetComponent<AudioSource> ();
		savedLevel = LevelState.none;
	}

	// Update is called once per frame
	void Update () {

		if (level != savedLevel) {
			
			switch (level) {
			case LevelState.level1:
				audio.clip = Resources.Load ("Jungle Japes - Donkey Kong 64") as AudioClip;
				break;

			case LevelState.level2:
				audio.clip = Resources.Load ("Journey Soundtrack (Austin Wintory) - 06. Third Confluence") as AudioClip;
				break;

			case LevelState.level3:
				audio.clip = Resources.Load ("Banjo-Tooie - Boss Theme #2 Targitzan") as AudioClip;
				break;

			case LevelState.Menu:
				audio.clip = Resources.Load ("Crash Bandicoot 1 Theme") as AudioClip;
				break;
			}

			audio.loop = true;
			audio.Play ();

			savedLevel = level;
		}

	}
}
