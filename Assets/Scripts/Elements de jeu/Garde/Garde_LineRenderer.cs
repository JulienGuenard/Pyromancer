#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Garde_LineRenderer : MonoBehaviour {

	static public int ChosenGroupTraj = 0;
	static public int ChosenTraj = 0;

	static public bool HasChanged = false;

	Garde_Patrol SC_Patrol;

	void Start () {
		SC_Patrol = GetComponent<Garde_Patrol> ();
	}

	public void LineRendererActing (List<GameObject> PointsRoutine, int GroupeRoutineActif, int RoutineActif, List<GameObject> Trajet, GameObject trajectoiregizmo, List<Component> linerendgroup, GameObject Waypoint_GMB, Color GizmoColor)
	{
		if (!Application.isPlaying) {

			TrajetCreation (Trajet, trajectoiregizmo, linerendgroup, GizmoColor);

			SelectionGarde (PointsRoutine, GroupeRoutineActif, RoutineActif, linerendgroup, Waypoint_GMB);

			if (HasChanged) {
				for (int i = 0; i < PointsRoutine.Count; i++) {
					PointsRoutine [i].transform.position = SC_Patrol.GR_Routine [ChosenGroupTraj].Routine [ChosenTraj].Waypoint [i];
				}
				HasChanged = false;
			}

			if (PointsRoutine.Count == SC_Patrol.GR_Routine [GroupeRoutineActif].Routine [RoutineActif].Waypoint.Count && !HasChanged) {
				for (int i = 0; i < PointsRoutine.Count; i++) {
					SC_Patrol.GR_Routine [ChosenGroupTraj].Routine [ChosenTraj].Waypoint [i] = PointsRoutine [i].transform.position;
				}
			}



			if (Trajet.Count == SC_Patrol.GR_Routine.Count) {
				for (int i = 0; i < SC_Patrol.GR_Routine.Count; i++) {
					if (Trajet [i] != null) {
						Trajet [i].GetComponent<LineRenderer> ().positionCount = SC_Patrol.GR_Routine [i].Routine [RoutineActif].Waypoint.Count;
						Trajet [i].GetComponent<LineRenderer> ().SetPositions (SC_Patrol.GR_Routine [i].Routine [RoutineActif].Waypoint.ToArray ());
					}
				}
			}


				
			

		}
	}

	void TrajetCreation (List<GameObject> Trajet, GameObject trajectoiregizmo, List<Component> linerendgroup, Color GizmoColor) {

		foreach (GameObject traj in Trajet) {
			if (traj == null) {
				Trajet.Remove (traj);
			}
		}

		if (Trajet.Count < SC_Patrol.GR_Routine.Count) {

			GameObject trajetgizmo = (GameObject)Instantiate (trajectoiregizmo, transform.position, transform.rotation);

		//if (trajetgizmo != null) {

				trajetgizmo.transform.parent = transform;
				Trajet.Add (trajetgizmo);
				linerendgroup.Add (trajetgizmo.GetComponent<LineRenderer> ());
		//	}

		} else {
			if (Trajet [0] != null) {
				LineRendererAttributes (Trajet, GizmoColor);


				foreach (GameObject objet in Trajet) {

					if (objet.tag != "Trajectoire") {
						Trajet.Remove (objet);
						DestroyImmediate (objet);
					}
				}
			}
		}
	}

	void SelectionGarde (List<GameObject> PointsRoutine, int GroupeRoutineActif, int RoutineActif, List<Component> linerendgroup, GameObject Waypoint_GMB) {
		if (Selection.Contains (this.gameObject)) {

			if (SC_Patrol.GR_Routine [GroupeRoutineActif].Routine [RoutineActif].Waypoint.Count != PointsRoutine.Count) {

				if (PointsRoutine.Count != 0) {
					foreach (GameObject objet in PointsRoutine) {
						DestroyImmediate (objet);
					}
					PointsRoutine.Clear ();

				}

				int Increment = -1;

				foreach (Vector3 point in SC_Patrol.GR_Routine[ChosenGroupTraj].Routine[ChosenTraj].Waypoint) {
					Increment++;
					GameObject PointRoutine = (GameObject)Instantiate (Waypoint_GMB, point + new Vector3 (0, 0, 0), Quaternion.identity);
					PointRoutine.transform.parent = transform;
					PointRoutine.name = Increment.ToString ();
					PointsRoutine.Add (PointRoutine);
				}

			}

			foreach (LineRenderer line in linerendgroup) {
				if (line != null) {
					line.enabled = true;
				}
			}

		} else {			
			StartCoroutine (DestroyDummy(PointsRoutine, linerendgroup));
		}
	}

	void LineRendererAttributes (List<GameObject> Trajet, Color GizmoColor) {
		for (int i = 0; i < SC_Patrol.GR_Routine.Count; i++) {
			Trajet [i].GetComponent<LineRenderer> ().startWidth = 0.35f / (i + 1);
			Trajet [i].GetComponent<LineRenderer> ().endWidth = 0.35f / (i + 1);
			Trajet [i].GetComponent<LineRenderer> ().startColor = GizmoColor + new Color (0, 0, 0, (0.3f / (i + 1)));
			Trajet [i].GetComponent<LineRenderer> ().endColor = GizmoColor + new Color (0, 0, 0, (0.3f / (i + 1)));
		}
	}

	IEnumerator DestroyDummy (List<GameObject> PointsRoutine, List<Component> linerendgroup) {
		yield return new WaitForSeconds (0.01f);
		if (Selection.activeGameObject != null) {
			if (Selection.activeGameObject.transform.parent == this.gameObject.transform.parent) {
				if (PointsRoutine.Count != 0) {
					foreach (GameObject objet in PointsRoutine) {
						DestroyImmediate (objet);
					}
					PointsRoutine.Clear ();

				}

				foreach (LineRenderer line in linerendgroup) {
					if (line != null) {
						line.enabled = false;
					}
				}
			}
		}

	}
}
#endif