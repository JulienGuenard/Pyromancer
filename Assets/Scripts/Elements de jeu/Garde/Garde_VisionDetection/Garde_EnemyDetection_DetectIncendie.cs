using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garde_EnemyDetection_DetectIncendie : MonoBehaviour {

	////////////////// DETECTION D'UNE MAISON EN FEU ? //////////////////

	void OnTriggerStay (Collider col) {
        if (col.tag == "Maison_Incendie" && GetComponentInParent<Garde_Patrol> ().GroupeRoutineActif != 1) {
			GetComponentInParent<Garde_Event>().Event1();
		}
	}

	////////////////////////////////////////////////////////////////////////
}
