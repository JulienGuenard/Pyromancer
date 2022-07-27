#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RangeurObjet : MonoBehaviour {
	
	GameObject GRP;
	public GameObject GRP_Brasero;
	public GameObject GRP_Limit;
	public GameObject GRP_Maison;
	public GameObject GRP_Exit;
	public GameObject GRP_Garde;
	public GameObject GRP_Player;
	public GameObject GRP_Terrain;
	public GameObject GRP_Plante;
	public GameObject GRP_Panthere;
	public GameObject GRP_Water;
	public GameObject GRP_Totem;
	public GameObject GRP_Vase;
	public GameObject GRP_Broussaille;
	public GameObject GRP_Barque;

	string GRP_Name;

	void Start () {

		GRP_Brasero = GRP_Instance ("GRP_Brasero");
		GRP_Limit = GRP_Instance ("GRP_Limit");
		GRP_Maison = GRP_Instance ("GRP_Maison");
		GRP_Exit = GRP_Instance ("GRP_Exit");
		GRP_Garde = GRP_Instance ("GRP_Garde");
		GRP_Player = GRP_Instance ("GRP_GRP_Player");
		GRP_Terrain = GRP_Instance ("GRP_Terrain");
		GRP_Plante = GRP_Instance ("GRP_Plante");
		GRP_Panthere = GRP_Instance ("GRP_Panthere");
		GRP_Water = GRP_Instance ("GRP_Water");
		GRP_Totem = GRP_Instance ("GRP_Totem");
		GRP_Vase = GRP_Instance ("GRP_Vase");
		GRP_Broussaille = GRP_Instance ("GRP_Broussaille");
		GRP_Barque = GRP_Instance ("GRP_Barque");
	
	}

	GameObject GRP_Instance (string GRP_Name) {

		if (GameObject.Find (GRP_Name) == null) {
			GRP = (GameObject)Instantiate (Resources.Load ("Editor/GRP"));
		} else {
			GRP = GameObject.Find (GRP_Name);
		}
		GRP.name = GRP_Name;
		GRP.transform.parent = GameObject.Find ("LEVEL").transform;
		return GRP;

	}

	void Update () {
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Brasero")) {
			objet.transform.parent = GRP_Brasero.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Limit")) {
			objet.transform.parent = GRP_Limit.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Maison")) {
			objet.transform.parent = GRP_Maison.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Exit")) {
			objet.transform.parent = GRP_Exit.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Garde_GMB")) {
			objet.transform.parent = GRP_Garde.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("GRP_Player")) {
			objet.transform.parent = GRP_Player.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Background")) {
			objet.transform.parent = GRP_Terrain.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Terrain")) {
			objet.transform.parent = GRP_Terrain.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Panthere")) {
			objet.transform.parent = GRP_Panthere.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Totem")) {
			objet.transform.parent = GRP_Totem.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Plante")) {
			objet.transform.parent = GRP_Plante.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Vase")) {
			objet.transform.parent = GRP_Vase.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Broussaille")) {
			objet.transform.parent = GRP_Broussaille.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Water")) {
			objet.transform.parent = GRP_Water.transform;
		}
		foreach (GameObject objet in GameObject.FindGameObjectsWithTag("Barque")) {
			objet.transform.parent = GRP_Barque.transform;
		}
	}
}
#endif