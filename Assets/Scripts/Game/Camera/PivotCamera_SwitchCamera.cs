using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotCamera_SwitchCamera : MonoBehaviour {

	PivotCamera_ControlCamera SC_ControlCamera;

	public Vector3 Cam1_Position;
	public Vector3 Cam2_Position;

	public Vector3 Cam1_Rotation;
	public Vector3 Cam2_Rotation;

	// Use this for initialization
	void Start () {
		SC_ControlCamera = GetComponent<PivotCamera_ControlCamera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			transform.parent = GameObject.Find ("Joueur").transform;

			SC_ControlCamera.LockedCamera = false;
			SC_ControlCamera.CamPositionChosen = Cam1_Position;
			SC_ControlCamera.CamRotationChosen = Cam1_Rotation;
		

		}

		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			transform.parent = GameObject.Find ("PlayerDetection").transform;

			SC_ControlCamera.LockedCamera = true;
			SC_ControlCamera.CamPositionChosen = Cam2_Position;
			SC_ControlCamera.CamRotationChosen = Cam2_Rotation;

			}
	}
}
