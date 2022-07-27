using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GR_Routine 0 :

// -- Defaut: Routine 0

//GR_Routine 1 :

// -- Event 1 Defaut: Routine 0

// -- Event 1 Nord: Routine 0
// -- Event 1 Est: Routine 1
// -- Event 1 Sud: Routine 2
// -- Event 1 Ouest: Routine 3

public class Garde_Event : MonoBehaviour {
 
	public string abcdef;

	////////////////// ACTIVATION D'UN NOUVEAU GROUPE DE ROUTINE (EVENT 1) //////////////////

	public void Event1 () { // Si le garde rencontre une maison incendiée, alors il se passe cette évènement
                            // Cela appelle le GR_Routine 1
                            //
                            // Si GR_Routine 1 ne comporte aucune routine, l'Event1 ne se poursuit pas.
                            // Si GR_Routine 1 ne comporte qu'une Routine, alors quelque soit la rotation du garde, il adopte cette Routine.
                            // Si GR_Routine 1 comporte 4 Routine, alors :
                            // Si le garde est tourné au nord : Routine 0
                            // Si le garde est tourné a l'est : Routine 1
                            // Si le garde est tourné au sud : Routine 2
                            // Si le garde est tourné a l'ouest : Routine 3

		if (GetComponentInParent<Garde_Patrol> ().Etat != "Poursuite") {
			GetComponentInParent<Garde_Patrol> ().GroupeRoutineActif = 1;
			GetComponentInParent<Garde_Patrol> ().RoutineActif = 0;
			GetComponentInParent<Garde_Patrol> ().Event_bool = true;


            // NORD
            if (GetComponentInParent<Garde_Patrol> ().GR_Routine[1].Routine.Count == 4 && (transform.rotation.eulerAngles.y >= 315 || transform.rotation.eulerAngles.y < 45)) {
                Debug.Log("called");

                GetComponentInParent<Garde_Patrol> ().RoutineActif = 0;
				}

				// EST
			if (GetComponentInParent<Garde_Patrol> ().GR_Routine[1].Routine.Count == 4  && (transform.rotation.eulerAngles.y >= 45 && transform.rotation.eulerAngles.y < 135)) {
                Debug.Log("called");

                GetComponentInParent<Garde_Patrol> ().RoutineActif = 1;
				}

				// SUD
			if (GetComponentInParent<Garde_Patrol> ().GR_Routine[1].Routine.Count == 4  && (transform.rotation.eulerAngles.y >= 135 && transform.rotation.eulerAngles.y < 225)) {
                Debug.Log("called");

                GetComponentInParent<Garde_Patrol> ().RoutineActif = 2;
				}

				// OUEST
			if (GetComponentInParent<Garde_Patrol> ().GR_Routine[1].Routine.Count == 4  && (transform.rotation.eulerAngles.y >= 225 && transform.rotation.eulerAngles.y < 315)) {
                Debug.Log("called");

                GetComponentInParent<Garde_Patrol> ().RoutineActif = 3;
				}
			
		}
	}

	////////////////////////////////////////////////////////////////////////////////////////////
}
