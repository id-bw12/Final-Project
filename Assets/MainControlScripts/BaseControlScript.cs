using UnityEngine;

public class BaseControlScript : MonoBehaviour
{

	protected enum MainStates{
		Main = 0,
        Play = 1,
		Options = 2,
		Credits = 3, 
		Exit = 4,
		None = 5
	}

	protected MainStates state = MainStates.None;

    protected GameObject canvas, panel, eventSystem;
}

