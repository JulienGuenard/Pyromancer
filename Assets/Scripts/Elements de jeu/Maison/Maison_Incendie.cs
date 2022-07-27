using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maison_Incendie : MonoBehaviour {

	////////////////// VARIABLES //////////////////

	public GameObject IncendieFX = null;

	public List<GameObject> BatChosen;

	///////////////////////////////////////////////

	////////////////// DEBUT INCENDIE //////////////////

	IEnumerator Incendie () { // Ce qu'il se passe lors d'un incendie

		tag = "Maison_Incendie";

		GetComponent<Maison_Transmission>().StartCoroutine ("Transmission");
	
		///////////////////////
		//// Appel du FX //////
		///////////////////////

		if (this.gameObject.name == "Maison_x2") {
		IncendieFX = GameObject.Find ("Incendie_FX_x2");
			}
		if (this.gameObject.name == "Maison_x1") {
		IncendieFX = GameObject.Find ("Incendie_FX_x1");
		}

        IncendieFX = GameObject.Instantiate(IncendieFX);
	    IncendieFX.transform.position = transform.position;

        //if (IncendieFX.GetComponentsInChildren<ParticleSystem> () != null) {
        foreach (ParticleSystem part in IncendieFX.GetComponentsInChildren<ParticleSystem> ()) {
			
				part.Play ();
//				part.Clear ();
			}
		
		
		//}
		string IncendieFX_name = IncendieFX.name;
		IncendieFX.name += "_used";
		IncendieFX.transform.position = transform.position;
		IncendieFX.transform.position += new Vector3 (-0.75f, 0, 0);

		///////////////////////
		///////////////////////

		for (int i = 0; i < 100; i++) {
			yield return new WaitForSeconds (0.01f);
			GetComponentInChildren<MeshRenderer> ().material.color += new Color (0.01f, -0.01f, -0.01f);

		}

		yield return new WaitForSeconds (4f);

		foreach (ParticleSystem part in IncendieFX.GetComponentsInChildren<ParticleSystem> ()) {
//			part.Clear ();
			part.Stop ();
		}
			
		IncendieFX.name = IncendieFX_name;
		IncendieFX.transform.position = new Vector3 (999,999,999);
		Destroy (this.gameObject);
	}

	//////////////////////////////////////////////
}
