using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur_Brasero : MonoBehaviour {

	GameObject Torche;
	Torche_Energie TorcheEnergie;

	// Use this for initialization
	void Start () {
		Torche = GameObject.Find ("Torche");
		TorcheEnergie = Torche.GetComponent<Torche_Energie> ();
	}

	void OnTriggerStay (Collider col) {
		if (col.tag == "Brasero") {
			TorcheEnergie.Brasero ();
		}
	}
}
