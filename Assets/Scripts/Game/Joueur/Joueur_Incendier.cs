using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joueur_Incendier : MonoBehaviour {

	////////////////// VARIABLES //////////////////

	public GameObject BatChosen = null;


    GameObject Torche;

    Torche_Energie TorcheEnergie;

	void GetComponents () {
		if (Torche == null && GameObject.Find("Torche") != null) {
	        Torche = GameObject.Find("Torche");
			if (TorcheEnergie == null) {
	            TorcheEnergie = Torche.GetComponent<Torche_Energie>();
	        }
	    }
	}
    /////////////////////////////////////////////

    // Update is called once per frame
    void Update () {
        GetComponents();

		if (Input.GetButtonDown ("Incendier") == true && BatChosen != null) {
			JoueurQuiIncendie ();
            GameObject.Find("Incendie_txt").GetComponent<Text>().color = new Color(255f, 0f, 0f, 0);
        }

    }

	////////////////// JOUEUR QUI INCENDIE UNE MAISON //////////////////

	void JoueurQuiIncendie () {

		GetComponentInChildren<Animator> ().SetTrigger ("Allume");
		GameObject BatIncendied = BatChosen;
        BatChosen = null;

        BatIncendied.GetComponent<Maison_SelectionJaune> ().DeselectionJaune ();
        BatIncendied.GetComponent<Maison_Incendie> ().StartCoroutine ("Incendie");

        TorcheEnergie.Incendie ();

    }

    ////////////////////////////////////////////////////////////////////

    ////////////////// DETECTION DE SI LE JOUEUR PEUT INCENDIER //////////////////

    void OnTriggerStay (Collider col) {
		if (col.tag == "Maison") {

            if (BatChosen == null) {
				BatChosen = col.gameObject;
				BatChosen.GetComponent<Maison_SelectionJaune> ().SelectionJaune ();
				BatChosen.GetComponentInChildren<MeshRenderer> ().material.color = new Color (0, 1, 0);
                GameObject.Find("Incendie_txt").GetComponent<Text>().color = new Color(255f, 180f, 0f, 255f);

            }



        }
	}

	void OnTriggerExit (Collider col) {

		if (col.tag == "Maison") {

			if (BatChosen != null) {
				BatChosen.GetComponent<Maison_SelectionJaune> ().DeselectionJaune ();
				BatChosen.GetComponentInChildren<MeshRenderer> ().material.color = new Color (1, 1, 1);
				BatChosen = null;
                GameObject.Find("Incendie_txt").GetComponent<Text>().color = new Color(255f, 180f, 0f, 0);
            }
        }
		}


	////////////////////////////////////////////////////////////////////////////////
		

}
