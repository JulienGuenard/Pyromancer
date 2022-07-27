using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceJoueur_BatimentRestant : MonoBehaviour {
	
	GameObject BatimentRestant;
	GameObject BatimentRestantImagePivot;


    bool OneTime = true;

	public float NombreBatiment = 0;

	void Start () {
		
		BatimentRestant = GameObject.Find ("BatimentRestant");
		BatimentRestantImagePivot = GameObject.Find ("BatimentRestantImagePivot");

	}
	void Update () {
	    NombreBatiment = GameObject.FindGameObjectsWithTag("Maison").Length +
	                     GameObject.FindGameObjectsWithTag("Maison_Incendie").Length;
        BatimentRestant.GetComponent<UnityEngine.UI.Text> ().text = " " + NombreBatiment.ToString ();
	}
}
