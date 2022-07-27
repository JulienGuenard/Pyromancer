using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur_PlayerDetection_Position : MonoBehaviour {

	GameObject Joueur;

	// Use this for initialization
	void Start () {
		Joueur = GameObject.Find ("Joueur");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Joueur.transform.position;
	}
}
