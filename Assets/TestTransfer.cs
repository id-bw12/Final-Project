using UnityEngine;
using System.Collections;

public class TestTransfer : MonoBehaviour {

    void Awake() {
        Debug.Log("Success");

        GameObject.Find("Control").AddComponent<Level1>();
    }
}
