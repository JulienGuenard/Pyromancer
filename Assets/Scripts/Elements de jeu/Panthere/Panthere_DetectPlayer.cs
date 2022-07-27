using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panthere_DetectPlayer : MonoBehaviour {

	////////////////// VARIABLES //////////////////

	GameObject Ecran_gmb;

	void Start () {
		Ecran_gmb = GameObject.Find ("SC_Ecran");
	}

	//////////////////////////////////////////////

	////////////////// GARDE DETECTE LE JOUEUR //////////////////

	void OnTriggerStay (Collider col) {
		if (col.tag == "Player") {

			Ecran_gmb.GetComponent<SC_Ecran_Perdu> ().Perdu();


		}
	}

	/////////////////////////////////////////////////////////////


}
