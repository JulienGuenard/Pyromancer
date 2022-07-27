using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_MenuInGame : MonoBehaviour {

	public GameObject GameMenu;

	public CursorLockMode cursorState;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!GameMenu.activeInHierarchy) {
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				GameMenu.SetActive (true);
			} else {
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Confined;
				GameMenu.SetActive (false);
			}

		}
				
		if (Input.GetKey (KeyCode.R)) {
			Recommencer ();
		}

	}

	public void Recommencer () {
		
		if (Menu_Boutons.SceneName != null) {
			SceneManager.LoadScene (SceneManager.GetSceneByName (Menu_Boutons.SceneName).name, LoadSceneMode.Single);
		} else {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name, LoadSceneMode.Single);
		}
		SceneManager.LoadScene ("Level_Backend", LoadSceneMode.Additive);
    }

    public void Options () {

	}

	public void MenuPrincipal () {
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}

	public void Retour () {
		GameMenu.SetActive (false);
	}

}
