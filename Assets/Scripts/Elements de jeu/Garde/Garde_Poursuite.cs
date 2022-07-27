using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garde_Poursuite : MonoBehaviour {

	[HideInInspector]
	public UnityEngine.AI.NavMeshAgent agent;

	public Vector3 destination;

	public GameObject Cible;

	public string Etat;

	Garde_Patrol GardePatrol;

	public float TempsPoursuite = 2f;
	// Use this for initialization
	void Start () {
		Cible = GameObject.Find ("Joueur");
		GardePatrol = GetComponent<Garde_Patrol> ();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {
		if (Etat == "Poursuite" && GardePatrol.Etat != "Trouve") {
			destination = Cible.transform.position;
			agent.SetDestination (destination);
		}
	}

	public IEnumerator PoursuiteTime () {
		yield return new WaitForSeconds(TempsPoursuite);

		Etat = "Idle";
		if (GardePatrol.Etat != "Trouve") {
			GardePatrol.Etat = GardePatrol.EtatPrecedent;
			GardePatrol.GoToWaypoint ();
		}
	}

}
