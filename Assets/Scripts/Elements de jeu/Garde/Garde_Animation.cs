using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garde_Animation : MonoBehaviour {

	public GameObject FX_Sleep;
	public GameObject FX_Alerte;
	public GameObject FX_Poursuite;
	public GameObject FX_Fuite;
	public GameObject FX_Etourdi;
	public GameObject ScanGMB;




	void Start () {
		FX_Sleep = GameObject.Find ("FX_Sleep");
		FX_Alerte = GameObject.Find ("FX_Alerte");
		FX_Alerte.name = "FX_Alerte_taken";
		FX_Poursuite = GameObject.Find ("FX_Poursuite");
		FX_Poursuite.name = "FX_Poursuite_taken";
		FX_Fuite = GameObject.Find ("FX_Fuite");
		FX_Fuite.name = "FX_Fuite_taken";
		FX_Etourdi = GameObject.Find ("FX_Etourdi");
		FX_Etourdi.name = "FX_Etourdi_taken";

		ScanGMB = transform.Find ("EnemyDetection").gameObject;

	}

	public void garde_animation (string Etat) {
			if (Etat == "Inactif") {
				Detection (false);
				GetComponentInChildren<Animator> ().SetTrigger ("Inactif");
				FX_Sleep.transform.position = transform.position;
				FX_Alerte.transform.position = new Vector3 (999, 999, 999);
				FX_Poursuite.transform.position = new Vector3 (999, 999, 999);
				FX_Fuite.transform.position = new Vector3 (999, 999, 999);
				FX_Etourdi.transform.position = new Vector3 (999, 999, 999);
			}

			if (Etat == "Actif") {
				Detection (true);
				GetComponentInChildren<Animator> ().SetTrigger ("Actif_ON");
				FX_Sleep.transform.position = new Vector3 (999, 999, 999);
				FX_Alerte.transform.position = new Vector3 (999, 999, 999);
				FX_Poursuite.transform.position = new Vector3 (999, 999, 999);
				FX_Fuite.transform.position = new Vector3 (999, 999, 999);
				FX_Etourdi.transform.position = new Vector3 (999, 999, 999);
			}

			if (Etat == "Alerte") {
				Detection (true);
				GetComponentInChildren<Animator> ().SetTrigger ("Actif_ON");
				FX_Sleep.transform.position = new Vector3 (999, 999, 999);
				FX_Alerte.transform.position = transform.position + new Vector3 (0, 2.5f, 0);
				FX_Poursuite.transform.position = new Vector3 (999, 999, 999);
				FX_Fuite.transform.position = new Vector3 (999, 999, 999);
				FX_Etourdi.transform.position = new Vector3 (999, 999, 999);
			}

			if (Etat == "Trouve") {
				Detection (true);
				GetComponentInChildren<Animator> ().SetTrigger ("Trouve");
				FX_Sleep.transform.position = new Vector3 (999, 999, 999);
				FX_Alerte.transform.position = new Vector3 (999, 999, 999);
				FX_Poursuite.transform.position = new Vector3 (999, 999, 999);
				FX_Fuite.transform.position = new Vector3 (999, 999, 999);
				FX_Etourdi.transform.position = new Vector3 (999, 999, 999);
			}

			if (Etat == "Poursuite") {
				Detection (true);
				//	GetComponentInChildren<Animator> ().SetTrigger ("Poursuite");
				FX_Sleep.transform.position = new Vector3 (999, 999, 999);
				FX_Alerte.transform.position = new Vector3 (999, 999, 999);
				FX_Poursuite.transform.position = transform.position + new Vector3 (0, 2.5f, 0);
				FX_Fuite.transform.position = new Vector3 (999, 999, 999);
				FX_Etourdi.transform.position = new Vector3 (999, 999, 999);

			}
			if (Etat == "Fuite") {
				Detection (true);
				//GetComponentInChildren<Animator> ().SetTrigger ("Poursuite");
				FX_Sleep.transform.position = new Vector3 (999, 999, 999);
				FX_Alerte.transform.position = new Vector3 (999, 999, 999);
				FX_Poursuite.transform.position = new Vector3 (999, 999, 999);
				FX_Fuite.transform.position = transform.position + new Vector3 (0, 2.5f, 0);
				FX_Etourdi.transform.position = new Vector3 (999, 999, 999);

			}

			if (Etat == "Etourdi") {
				Detection (true);
				//GetComponentInChildren<Animator> ().SetTrigger ("Poursuite");
				FX_Sleep.transform.position = new Vector3 (999, 999, 999);
				FX_Alerte.transform.position = new Vector3 (999, 999, 999);
				FX_Poursuite.transform.position = new Vector3 (999, 999, 999);
				FX_Fuite.transform.position = new Vector3 (999, 999f, 999);
				FX_Etourdi.transform.position = transform.position + new Vector3 (0, 2.5f, 0);

			}
	}

	void Detection (bool statut) {
		if (ScanGMB.activeInHierarchy != true) {
			ScanGMB.SetActive (statut);
			ScanGMB.GetComponent<Garde_EnemyDetection_Scan> ().StartCoroutine ("Scan");
		}
	}
}
