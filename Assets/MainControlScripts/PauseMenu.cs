using UnityEngine;
using System.Collections;

public class PauseMenu : BaseControlScript
{
    private UIMakerScript ui = new UIMakerScript();

    public void CheckGameState() {

        if (game == GameState.Pause)
        {
            Time.timeScale = 0;
            PauseGame();
        }
        else
            if (game == GameState.None)
        {
            Time.timeScale = 1;
            UnpausedGame();
        }
        

    }

    void PauseGame() {
        canvas = ui.CreateCanvas(this.transform);

        eventSystem = ui.CreateEventSystem(canvas.transform);
    }

    void UnpausedGame() {
        GameObject.Destroy(canvas);

    }
}
