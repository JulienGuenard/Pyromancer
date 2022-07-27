using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Ecran_Victoire : MonoBehaviour {

	////////////////// VARIABLES //////////////////

	GameObject Fade_txt;
	GameObject Joueur;

	/////////////////////////////////////////////////

	////////////////// VICTOIRE //////////////////

	public void Victoire () { // Ce qu'il se passe lorsque l'on gagne le niveau
	    if (Joueur == null) {
            Joueur = GameObject.Find("Joueur");
        }
	    if (Fade_txt == null) {
	        Fade_txt = GameObject.Find("Fade_txt");
	    }

	    Joueur.GetComponent<Joueur_Deplacement> ().enabled = false;
		Joueur.GetComponentInChildren<Joueur_Incendier> ().enabled = false;
		Joueur.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);

		Fade_txt.GetComponent<UnityEngine.UI.Text> ().text = "Good Game";
		Fade_txt.GetComponent<UnityEngine.UI.Text> ().color = new Color (0f, 1f, 0f, 0f);

        ButtonActivating.Victory(Menu_Boutons.SceneName);
        GetComponent<SC_Ecran_Fade>().StartCoroutine ("Fade");
	}

	////////////////////////////////////////////
}
