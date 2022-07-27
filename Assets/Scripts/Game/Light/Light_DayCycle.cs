using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_DayCycle : MonoBehaviour {

	////////////////// VARIABLES //////////////////

	public float VitesseSoleil;
	public float SoleilPosition;

	//////////////////////////////////////////////

	// Update is called once per frame
	void Update () {

		transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.AngleAxis (SoleilPosition, Vector3.right), VitesseSoleil);

		if (transform.rotation.eulerAngles.x == 90) {
			SoleilPosition = 179;
		}
		if (transform.rotation.eulerAngles.x == 1.000003f) {
			SoleilPosition = 270;
		}

		if (transform.rotation.eulerAngles.x == 270) {
			SoleilPosition = 0;
		}

		if (transform.rotation.eulerAngles.x == 0) {
			SoleilPosition = 90;
		}


	}
}
