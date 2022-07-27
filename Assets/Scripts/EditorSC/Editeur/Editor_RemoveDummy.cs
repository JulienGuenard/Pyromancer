using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Editor_RemoveDummy : MonoBehaviour {

	void Start () {
			foreach (GameObject dummy in GameObject.FindGameObjectsWithTag("Dummy")) {
				DestroyImmediate (dummy);
		}
		foreach (GameObject traj in GameObject.FindGameObjectsWithTag("Trajectoire")) {
			DestroyImmediate (traj);
		}
	}
}
