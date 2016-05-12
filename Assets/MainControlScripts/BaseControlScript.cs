using UnityEngine;

public class BaseControlScript : MonoBehaviour
{

	protected enum MenuStates{
		Main = 0,
        Play = 1,
		Options = 2,
		Credits = 3, 
		Exit = 4,
		None = 5
	}

    protected enum GameState {
        None = 0,
        Pause = 1
    }

	protected MenuStates state = MenuStates.None;

    protected GameState game = GameState.None;

    protected GameObject canvas, panel, eventSystem;

    protected float musicVolume = 100f, soundEffectVolume = 100f; 
}

