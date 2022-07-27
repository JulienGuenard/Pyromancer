using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maison_Transmission : MonoBehaviour {

	////////////////// VARIABLES //////////////////

	public List<GameObject> BatChosen;

	///////////////////////////////////////////////

	////////////////// DETECTION TRANSMISSION //////////////////



	void OnTriggerEnter(Collider col) {

		if (col.tag == "Maison") {

			bool NoDoublonAccepted = true;

			foreach (GameObject Bat in BatChosen) {
				if (Bat == col.gameObject) {
					NoDoublonAccepted = false;
				}
			}

			if (NoDoublonAccepted) {
				BatChosen.Add (col.gameObject);
			}
		}


	}

	////////////////////////////////////////////////////////////

	////////////////// TRANSMISSION D'UN BATIMENT A UN AUTRE DE L'INCENDIE //////////////////

	IEnumerator Transmission () { // Ce qu'il se passe lorsque l'incendie se "transmet" à un autre batiment

		yield return new WaitForSeconds (2f);
		foreach (GameObject Bat in BatChosen) {
			if (Bat != null) {
				if (Bat.tag == "Maison") {
					Bat.GetComponent<Maison_Incendie> ().StartCoroutine ("Incendie");
				}
			}
		}
	}

	////////////////////////////////////////////////////////////////////////////////////////////
}
