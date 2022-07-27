using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garde_Alerte : MonoBehaviour {

	Garde_Patrol SC_Patrol;

	void Start () {
		SC_Patrol = GetComponent<Garde_Patrol> ();
	}

	public void En_Alerte () {
		SC_Patrol.StopCoroutine ("DelaiRot");
		SC_Patrol.Etat = "Alerte";
		SC_Patrol.WaypointActif = 0;
		SC_Patrol.GoToWaypoint ();
		SC_Patrol.StartCoroutine ("DelaiRot");
	}
}
