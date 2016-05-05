using UnityEngine;

public class BaseControlScript : MonoBehaviour
{

	protected enum MainStates{
		Main = 0,
		Options = 1,
		Credits = 2, 
		Exit = 3,
		None = 4
	}

	protected MainStates state = MainStates.None;

    protected GameObject canvas, panel, eventSystem;
}

