using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garde_IncendieDetectionEndormi : MonoBehaviour {

	public Garde_Event GardeEvent;
	public Garde_Patrol GardePatrol;

	void Start () {
		GardeEvent = GetComponentInParent<Garde_Event> ();
		GardePatrol = GetComponentInParent<Garde_Patrol> ();
	}

	void OnTriggerStay (Collider col) {

        if (col.gameObject.tag == "Maison_Incendie" && GardePatrol.Etat == "Inactif") {
            GardeEvent.Event1 ();
			GardePatrol.Etat = "Alerte";
			GardePatrol.GoToWaypoint ();
            Destroy(this);
			}


	}

}
