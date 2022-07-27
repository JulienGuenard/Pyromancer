using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garde_Activity : MonoBehaviour {

	public Vector3 destination;

	Garde_Patrol SC_Patrol;

	void Start () {
		SC_Patrol = GetComponent<Garde_Patrol> ();
	}

	public void Patrouille (int WaypointActif, int GroupeRoutineActif, int RoutineActif, bool LoopPatrol) {
        if (Application.isPlaying) {
			if (SC_Patrol.GR_Routine [GroupeRoutineActif].Routine [RoutineActif].Waypoint.Count != 0) {
                if (transform.position.x == destination.x && transform.position.z == destination.z) {
					if (!LoopPatrol) {
                        if (SC_Patrol.GR_Routine [GroupeRoutineActif].Routine [RoutineActif].Waypoint.Count != WaypointActif + 1) {
							SC_Patrol.WaypointActif++;
						}
					} else {
                        SC_Patrol.WaypointActif++;
					}
					if (SC_Patrol.WaypointActif == SC_Patrol.GR_Routine [GroupeRoutineActif].Routine [RoutineActif].Waypoint.Count && LoopPatrol) {

                        SC_Patrol.WaypointActif = 0;

					}

					if (Application.isPlaying) {
                        SC_Patrol.GoToWaypoint ();
					}

					SC_Patrol.StartCoroutine ("DelaiRot");
                }
            }
		}
	}
}
