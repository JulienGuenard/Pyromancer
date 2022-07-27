using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase_Collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col) {
		if (col.collider.tag == "Terrain" && this.tag == "VasePris") {
			Destroy (this.gameObject);
		}
        if (col.collider.GetComponent<Etourdissable>() != null) {
            Debug.Log(col);
            col.collider.GetComponent<Etourdissable>().StartCoroutine("Etourdissement");
            Destroy(this.gameObject);
        }
        if (col.collider.GetComponentInParent<Etourdissable>() != null) { //TODO Enlever ceci
            Debug.Log(col);
            col.collider.GetComponentInParent<Etourdissable>().StartCoroutine("Etourdissement");
            Destroy(this.gameObject);
        }

    }

}
