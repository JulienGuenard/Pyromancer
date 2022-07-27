using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur_Deplacement : MonoBehaviour {

	////////////////// VARIABLES //////////////////

	public float Speed;
	public float SpeedSave;
	public float RotationSpeed;
	float Horizontal;
	float Vertical;

	GameObject PivotCamera;

	Rigidbody rigid;

	Vector3 MoveVelo;

	void Start () {

		SpeedSave = Speed;

		PivotCamera = GameObject.Find ("PivotCamera");

		rigid = GetComponent<Rigidbody> ();
	}

	//////////////////////////////////////////////////////

	////////////////// DEPLACEMENT DU JOUEUR //////////////////

	void Update () {

		Horizontal = Input.GetAxis("Horizontal");
		Vertical = Input.GetAxis("Vertical");

		if (Vertical < 0) {
			GetComponentInChildren<Animator> ().ResetTrigger ("Idle");
			GetComponentInChildren<Animator> ().SetTrigger ("Marche");
		}

		if (Vertical > 0) {
			GetComponentInChildren<Animator> ().ResetTrigger ("Idle");
			GetComponentInChildren<Animator> ().SetTrigger ("Marche");
		}

		if (Vertical == 0) {
			GetComponentInChildren<Animator> ().ResetTrigger ("Marche");
			GetComponentInChildren<Animator> ().SetTrigger ("Idle");
		}


		if (Horizontal < 0) {



			transform.Rotate(0, -RotationSpeed, 0);
			PivotCamera.transform.Rotate(0, RotationSpeed, 0);
		}
		if (Horizontal > 0) {



			transform.Rotate(0, RotationSpeed, 0);
			PivotCamera.transform.Rotate(0, -RotationSpeed, 0);
		}
		if (Horizontal == 0) {



			transform.Rotate(0, 0, 0);
			PivotCamera.transform.Rotate(0, 0, 0);
		}

		MoveVelo = /*transform.right * (Horizontal * Speed) + */transform.forward * (Vertical * Speed);
		MoveVelo.y = rigid.velocity.y;

		rigid.velocity = MoveVelo;


	}

	//////////////////////////////////////////////////////

}

