using UnityEngine;

public class BaseControlScript : MonoBehaviour
{

	protected enum MenuStates{
		
		Main = 0,
        Play = 1,
		instructions = 2,
		Options = 3,
		Credits = 4, 
		Exit = 5,
		SplashScreen = 6,
		None = 7
	}

    protected enum GameState {
        None = 0,
        Pause = 1
    }

	protected enum LevelState{
		none = 0,
		level1 = 1,
		level2 = 2,
		level3 = 3,
		Menu = 4

	}

	protected static MenuStates state = MenuStates.None;

    protected GameState game = GameState.None;

	protected static LevelState level = LevelState.Menu;

    protected GameObject canvas, panel, eventSystem;

    protected float musicVolume = 100f, soundEffectVolume = 100f; 
}