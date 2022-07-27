using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plante_Stick : MonoBehaviour {

	GameObject PlayerGMB;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col) {
		
		if (col.tag == "Player") {
			if (col.GetComponent<Joueur_Deplacement> () != null) {
				col.GetComponent<Joueur_Deplacement> ().Speed = 1f;
			}
		}
		if (col.tag == "Garde_GMB") {
			col.GetComponent<Garde_Patrol> ().Speed_Normal = 1f;
		}
		if (col.tag == "Panthere") {
			col.GetComponent<Panthere_Poursuite> ().Speed = 1f;
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.tag == "Player") {
			if (col.GetComponent<Joueur_Deplacement> () != null) {
				col.GetComponent<Joueur_Deplacement> ().Speed = col.GetComponent<Joueur_Deplacement> ().SpeedSave;
			}
		}
		if (col.tag == "Garde_GMB") {
			col.GetComponent<Garde_Patrol> ().Speed_Normal = col.GetComponent<Garde_Patrol> ().Speed_NormalSave;
		}
		if (col.tag == "Panthere") {
			col.GetComponent<Panthere_Poursuite> ().Speed = col.GetComponent<Panthere_Poursuite> ().SpeedSave;
		}
	}
}
