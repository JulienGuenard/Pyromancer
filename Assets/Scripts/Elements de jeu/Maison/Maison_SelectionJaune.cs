using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maison_SelectionJaune : MonoBehaviour {

	public Color SelectJaune_color;

	public MeshRenderer mesh;

	List<GameObject> BatChosen;

	Maison_Transmission SC_Transmission;

	// Use this for initialization
	void Start () {
		SelectJaune_color = new Color (1, 1, 0);
		mesh = GetComponentInChildren<MeshRenderer> ();
		SC_Transmission = GetComponent<Maison_Transmission> ();
	}

	public void SelectionJaune () {
		BatChosen = SC_Transmission.BatChosen;
		if (mesh.material.color != new Color (1, 1, 0)) {
		foreach (GameObject bat in BatChosen) {
				mesh.material.color = new Color (1, 1, 0);
				bat.GetComponent<Maison_SelectionJaune> ().SelectionJaune ();
			}
		}

	}

	public void DeselectionJaune () {
		BatChosen = SC_Transmission.BatChosen;
		if (mesh.material.color != new Color (1, 1, 1)) {
		foreach (GameObject bat in BatChosen) {
				mesh.material.color = new Color (1, 1, 1);
				bat.GetComponent<Maison_SelectionJaune> ().DeselectionJaune ();
			}
		}

	}
}

