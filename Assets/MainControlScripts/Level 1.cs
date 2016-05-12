using UnityEngine;
using System.Collections;

public class Level1 : BaseControlScript {


    void Awake(){

        Destroy(this.GetComponent<MainScript>());
        this.gameObject.AddComponent<PauseMenu>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P)) {

            if (game == GameState.Pause)
                game = GameState.None;
            else
                if (game == GameState.None)
                    game = GameState.Pause;

            this.GetComponent<PauseMenu>().CheckGameState();
        }

	}
}
