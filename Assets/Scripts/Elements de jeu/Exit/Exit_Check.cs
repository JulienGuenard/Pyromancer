using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Check : MonoBehaviour {

	////////////////// VARIABLES //////////////////

	GameObject Ecran_gmb;
    private Collider selfCollider;
    private bool winAllowed;
    public static bool exited;

    // Use this for initialization
    void Start () {
		Ecran_gmb = GameObject.Find ("SC_Ecran");
	    selfCollider = GetComponent<BoxCollider>();
        selfCollider.isTrigger = false;
	    winAllowed = false;
	}

    void Update() {
        if (winAllowed)
            return;
        if (GameObject.FindGameObjectsWithTag("Maison").Length == 0
            && GameObject.FindGameObjectsWithTag("Maison_Incendie").Length == 0) {
            selfCollider.isTrigger = true;
            winAllowed = true;
        }
    }

        /////////////////////////////////////////////

        ////////////////// DETECTION LORS D'UNE SORTIE //////////////////

        void OnTriggerEnter (Collider col) {
		if (col.tag == "Player") {
			if (winAllowed) {
			    selfCollider.isTrigger = true;
				Ecran_gmb.GetComponent<SC_Ecran_Victoire> ().Victoire();
			    exited = true;
			} else {
				GetComponent<Exit_Requirement> ().StartCoroutine ("Requirement");
			}
		}
	}

	/////////////////////////////////////////////////////////////
}
