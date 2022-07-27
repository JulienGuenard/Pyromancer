using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Requirement : MonoBehaviour {

	////////////////// VARIABLES //////////////////

	GameObject Requirement_txt;

	// Use this for initialization
	void Start () {
		Requirement_txt = GameObject.Find ("Requirement_txt");
	}

	/////////////////////////////////////////////

	////////////////// LE JOUEUR A T-IL REMPLI SON OBJECTIF //////////////////
	
	IEnumerator Requirement () { // Lorsque l'on prend une sortie, s'affiche si on a pas brûler tous les bâtiments

		Requirement_txt.GetComponent<UnityEngine.UI.Text> ().text = string.Concat ("Il reste encore ", GameObject.FindGameObjectsWithTag ("Maison").Length + GameObject.FindGameObjectsWithTag("Maison_Incendie").Length, " maison(s) à brûler dans la zone.");
		Requirement_txt.GetComponent<UnityEngine.UI.Text> ().color += new Color (0f, 0f, 0f, 1f);

		for (int i = 0; i < 100; i++) {
			yield return new WaitForSeconds (0.01f);
			Requirement_txt.GetComponent<UnityEngine.UI.Text> ().color -= new Color (0f, 0f, 0f, 0.01f);

		}
	}

	//////////////////////////////////////////////////////////////////////

}
