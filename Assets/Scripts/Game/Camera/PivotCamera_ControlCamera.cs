using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotCamera_ControlCamera : MonoBehaviour {

	////////////////// VARIABLES //////////////////
	//
	public bool LockedCamera;

	public Vector3 CamPositionChosen;
	public Vector3 CamRotationChosen;

	[Header("Paramètres Caméra")]
	public float horizontalSpeed = 2.0F;
	public float verticalSpeed = 2.0F;

	public bool VerticalCameraInclinaison;
	public float VerticalCameraInclinaison_MaximumHauteur;
	public float VerticalCameraInclinaison_MinimumHauteur;

	[Header("[Realtime] Variables")]
	public CursorLockMode cursoreState;
	public float horizontal;
	public float vertical;

	void Start() {

		///////////////////////////////////////////////

		Cursor.visible = false;
		Cursor.lockState = cursoreState;
	}



	void Update() {
		horizontal = horizontalSpeed * Input.GetAxis("Mouse X");
		vertical = verticalSpeed * -Input.GetAxis("Mouse Y");
		if (VerticalCameraInclinaison) {
			vertical = 0;
		} else {
			
			if (vertical < 0 && transform.localRotation.eulerAngles.x < VerticalCameraInclinaison_MaximumHauteur && transform.localRotation.eulerAngles.x > VerticalCameraInclinaison_MaximumHauteur - 50) {
				vertical = 0;
			}

			if (vertical > 0 && transform.localRotation.eulerAngles.x < VerticalCameraInclinaison_MinimumHauteur && transform.localRotation.eulerAngles.x > VerticalCameraInclinaison_MinimumHauteur - 50) {
				vertical = 0;
			}

		}




		transform.Rotate(vertical, horizontal, 0);
		transform.localPosition = CamPositionChosen;

		if (LockedCamera) {
			transform.rotation = Quaternion.Euler (CamRotationChosen);
		}
		transform.localRotation = Quaternion.Euler (transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, 0);
	}



}
