using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class Garde_Patrol : Etourdissable {

	////////////////// VARIABLES //////////////////

	public string abcd = "aaa";

	float UpdateWaitTime = 0;

	GameState GameS;

	Vector3 destination;

	public float AlerteBuffActual;
	public float AlerteBuff;
	public float TotemBuff;

	#if UNITY_EDITOR
	Garde_LineRenderer SC_LineRenderer;
	#endif

	Garde_Activity SC_Activity;
	Garde_Alerte SC_Alerte;
	Garde_Animation SC_Animation;

	public List<Component> linerendgroup;

	public enum ListeEtat {Actif, Inactif, Alerte, Poursuite, Trouve};

	[Header("Stats du garde")]
	public float Speed_Normal;
	public float Speed_NormalSave;
	//public float Speed_Alerte;
	public float rot_speed;
	public bool LoopPatrol;
	public ListeEtat EtatDuGarde;
	public string Etat;
	public string EtatPrecedent;

	[Header("Dessin de la trajectoire")]
	public Color GizmoColor;

	[System.Serializable]
	public struct Rout {
		public List<Vector3> Waypoint;
	}
	[System.Serializable]
	public struct GRout {
		public List<Rout> Routine;
	}
	[Header("Trajectoire")]
	public List<GRout> GR_Routine;

	[Header("Prefab du Gizmo de la Trajectoire")]
	public GameObject trajectoiregizmo;

	[HideInInspector]
	public UnityEngine.AI.NavMeshAgent agent;

	[Header("[REALTIME] Variables")]
	public int WaypointActif = 0; // Numéro du waypoint
	public int RoutineActif = 0; // Numéro de routine
	public int GroupeRoutineActif = 0; // Numéro de GR_routine

	[HideInInspector]
	public bool Event_bool = true;
	//[HideInInspector]
	public List<GameObject> PointsRoutine;

	public List<GameObject> Trajet;

	public GameObject Waypoint_GMB;

	public bool PoursuiteEvent = false;

	Garde_Poursuite GardePoursuite;

	void Start () {

		GameS = GameObject.Find ("rootScripts").GetComponent<GameState> ();

		Speed_NormalSave = Speed_Normal;

		GardePoursuite = GetComponent<Garde_Poursuite> ();

		WaypointActif = 1;

		destination = transform.position;
		#if UNITY_EDITOR
		SC_LineRenderer = GetComponent<Garde_LineRenderer> ();
		#endif
		SC_Alerte = GetComponent<Garde_Alerte> ();
		SC_Animation = GetComponent<Garde_Animation>();
		SC_Activity = GetComponent<Garde_Activity>();

		Trajet.Clear ();
		linerendgroup.Clear ();
			if (PointsRoutine.Count != 0) {
				foreach (GameObject objet in PointsRoutine) {
					DestroyImmediate (objet);
				}
				PointsRoutine.Clear ();
			}

			foreach (LineRenderer line in linerendgroup) {
				line.enabled = false;
			}

		Etat = EtatDuGarde.ToString();

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

		if (GR_Routine[GroupeRoutineActif].Routine [RoutineActif].Waypoint.Count != 0 && Etat != "Inactif") {

			if (Application.isPlaying) {
				GoToWaypoint ();
			}

			foreach (GameObject trajet in GameObject.FindGameObjectsWithTag("Trajectoire")) {
				DestroyImmediate (trajet);
			}
			Trajet.Clear();
			linerendgroup.Clear ();
		}

		agent.speed = 0.1f;

		//////////////////////////////////////////////
	
		////////////////// INIT /////////////////////
	
		StartCoroutine ("DelaiRot");
	}

	//////////////////////////////////////////////

	void Update () {

		if (!Application.isPlaying && UpdateWaitTime >= 1) {
			#if UNITY_EDITOR
			SC_LineRenderer.LineRendererActing (PointsRoutine, GroupeRoutineActif, RoutineActif, Trajet, trajectoiregizmo, linerendgroup, Waypoint_GMB, GizmoColor);
			#endif
		}
		if (!Application.isPlaying && UpdateWaitTime < 1) {
			UpdateWaitTime++;
		}

		if (GameS.GameEnd == false) {
			Etat = "Trouve";
		}

		if (PoursuiteEvent && Etat != "Trouve") {
			PoursuiteEvent = false;
			EtatPrecedent = Etat;
			Etat = "Poursuite";
			GardePoursuite.Etat = "Poursuite";
			GardePoursuite.StopCoroutine ("PoursuiteTime");
			GardePoursuite.StartCoroutine("PoursuiteTime");
		}

		agent.speed = Speed_Normal + AlerteBuffActual + TotemBuff - EtourdissementSpeed;



		// Animations du garde
		if (Application.isPlaying) {
			SC_Animation.garde_animation (Etat);
		}

		// Si le garde est alerté
		if (Event_bool && Etat != "Alerte" && Etat != "Poursuite") {
			SC_Alerte.En_Alerte ();
		}

		// Si le garde n'est pas endormi, alors il fera sa patrouille
		if (Etat != "Inactif") {
			SC_Activity.Patrouille (WaypointActif, GroupeRoutineActif, RoutineActif, LoopPatrol);
		}


	}
		
	public IEnumerator DelaiRot () { // Cette fonction permet que lorsque le garde atteint un point, qu'il n'aille pas directement à un autre point, GroupeRoutineActif'est pour lui laisser le temps de tourner.
		agent.speed = 0.1f;
		yield return new WaitForSeconds(rot_speed);
		if (Etat == "Alerte") {
			AlerteBuffActual = AlerteBuff;
		} else {
			AlerteBuffActual = 0f;
		}
		agent.acceleration = 45f;
	}

	public void GoToWaypoint () {
		destination = GR_Routine [GroupeRoutineActif].Routine [RoutineActif].Waypoint [WaypointActif] + new Vector3 (Random.Range (-0.5f,0.5f), 0, Random.Range (-0.5f,0.5f));
		agent.SetDestination (destination);
		SC_Activity.destination = destination;
	}

	public void Call_LineRenderer () {
		#if UNITY_EDITOR
		SC_LineRenderer.LineRendererActing (PointsRoutine, GroupeRoutineActif, RoutineActif, Trajet, trajectoiregizmo, linerendgroup, Waypoint_GMB, GizmoColor);
		#endif
	}

}
