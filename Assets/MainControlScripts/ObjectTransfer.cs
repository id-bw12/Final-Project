using UnityEngine;
using System.Collections;

public class ObjectTransfer : MonoBehaviour {

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}
