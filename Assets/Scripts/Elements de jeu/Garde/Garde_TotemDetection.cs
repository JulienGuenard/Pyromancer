using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garde_TotemDetection : MonoBehaviour {

	public float TotemBuff;

	Garde_Patrol GardePatrol;

	// Use this for initialization
	void Start () {
		GardePatrol = GetComponent<Garde_Patrol> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay (Collider col) {
		if (col.tag == "TotemZone") {
			GardePatrol.TotemBuff = TotemBuff;
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.tag == "TotemZone") {
			GardePatrol.TotemBuff = 0;
		}
	}

}
