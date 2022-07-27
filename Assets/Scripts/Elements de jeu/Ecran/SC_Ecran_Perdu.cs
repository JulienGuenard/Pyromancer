using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SC_Ecran_Perdu : MonoBehaviour {

	////////////////// VARIABLES //////////////////

	GameObject Fade_txt;
	GameObject Joueur;

	/////////////////////////////////////////////////

	////////////////// PERDU //////////////////

	public void Perdu () { // Ce qu'il se passe lorsque l'on perd le niveau

        if (Joueur == null) {
            Joueur = GameObject.Find("Joueur");
        }
        if (Fade_txt == null) {
            Fade_txt = GameObject.Find("Fade_txt");
        }

        Joueur.GetComponent<Joueur_Deplacement> ().enabled = false;
		Joueur.GetComponentInChildren<Joueur_Incendier> ().enabled = false;
		Joueur.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);

		Fade_txt.GetComponent<UnityEngine.UI.Text> ().text = "Game Over";
		Fade_txt.GetComponent<UnityEngine.UI.Text> ().color = new Color (1f, 0f, 0f, 0f);

		GetComponent<SC_Ecran_Fade>().StartCoroutine ("Fade");

	}

	////////////////////////////////////////////


}
