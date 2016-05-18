using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(0.0f,1.0f,0.0f);
	}
}
