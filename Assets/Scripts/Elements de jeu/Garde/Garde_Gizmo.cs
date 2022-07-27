using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Garde_Gizmo : MonoBehaviour {/*
	
	[System.Serializable]
	public struct Rout {
		public List<Vector3> Waypoint;
	}
	[System.Serializable]
	public struct GRout {
		public List<Rout> Routine;
	}
	public List<GRout> GR_Routine;

	public List<GameObject> Trajet;

	public List<Component> linerendgroup;
	public int RoutineActif = 0; // Numéro de routine
	public GameObject trajectoiregizmo;

	void Start () {

		RoutineActif = GetComponent<Garde_Patrol> ().RoutineActif;
		trajectoiregizmo = GetComponent<Garde_Patrol> ().trajectoiregizmo;
	}

	void Update () {
		if (!Application.isPlaying) {

			RoutineActif = GetComponent<Garde_Patrol> ().RoutineActif;
			trajectoiregizmo = GetComponent<Garde_Patrol> ().trajectoiregizmo;

			if (Trajet.Count < GetComponent<Garde_Patrol> ().GR_Routine.Count) {

				GameObject trajetgizmo = (GameObject)Instantiate (trajectoiregizmo, transform.position, transform.rotation);

				if (trajetgizmo != null) {
					trajetgizmo.transform.parent = transform;
					trajetgizmo.SetActive (true);
					Trajet.Add (trajetgizmo);
					linerendgroup.Add (trajetgizmo.GetComponent<LineRenderer> ());
				}

			} else {
				foreach (GameObject objet in Trajet) {

					if (objet.tag != "Trajectoire") {
						Trajet.Remove (objet);
						DestroyImmediate (objet);
					}
				}
			}

			if (Trajet.Count == GetComponent<Garde_Patrol> ().GR_Routine.Count) {
				for (int i = 0; i < GetComponent<Garde_Patrol> ().GR_Routine.Count; i++) {
					Trajet [i].GetComponent<LineRenderer> ().positionCount = GetComponent<Garde_Patrol> ().GR_Routine[i].Routine [RoutineActif].Waypoint.Count;
					Trajet [i].GetComponent<LineRenderer> ().SetPositions (GetComponent<Garde_Patrol> ().GR_Routine[i].Routine [RoutineActif].Waypoint.ToArray ());
				}
			}
		}
	}*/
}
