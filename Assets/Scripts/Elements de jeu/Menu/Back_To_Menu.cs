using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_To_Menu : MonoBehaviour {

    // Use this for initialization
    void Start() {
        if (Menu_Boutons.SceneName != null)
            Menu_Boutons.SceneName = null;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update() {}
}
