using UnityEngine;
using System.Collections;

public class TestTransfer : MonoBehaviour {

    void Awake() {
        Debug.Log("Success");

        if(GameObject.Find("Control") != null)
            GameObject.Find("Control").AddComponent<Level1>();
    }
}
