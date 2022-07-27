using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garde_EnemyDetection_DetectPlayer : MonoBehaviour {

	////////////////// VARIABLES //////////////////

	GameObject Ecran_gmb;

	void Start () {
		Ecran_gmb = GameObject.Find ("SC_Ecran");
	}

	//////////////////////////////////////////////

	////////////////// GARDE DETECTE LE JOUEUR //////////////////

	void OnTriggerStay (Collider col) {
	    if (Exit_Check.exited) {
	        return;
	    }

	    if (col.tag == "Player") {

			col.tag = "PlayerDetected";

			foreach (GameObject garde in GameObject.FindGameObjectsWithTag("Garde")) {
				garde.GetComponent<Animator> ().SetTrigger ("Trouve");
				garde.GetComponentInParent<Garde_Patrol> ().agent.enabled = false;
			}

			GetComponentInParent<Garde_Patrol> ().enabled = false;
			Ecran_gmb.GetComponent<SC_Ecran_Perdu> ().Perdu();


		}
	}

	/////////////////////////////////////////////////////////////


}
