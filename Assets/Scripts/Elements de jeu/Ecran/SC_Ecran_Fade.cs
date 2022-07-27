using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Ecran_Fade : MonoBehaviour {

	////////////////// VARIABLES //////////////////

	GameObject Fade_gmb;
	GameObject Fade_txt;

	void Start () {
		Fade_gmb = GameObject.Find ("Fade");
		Fade_txt = GameObject.Find ("Fade_txt");


	}

	/////////////////////////////////////////////////

	////////////////// FADE //////////////////

	IEnumerator Fade () { // Déclenche un écran noir qui apparaît qui apparaît progressivement, puis le niveau reboot
		for (int i = 0; i < 50; i++) {
			yield return new WaitForSeconds (0.01f);
			Fade_gmb.GetComponent<UnityEngine.UI.Image> ().color += new Color (0f, 0f, 0f, 0.02f);

		}

		for (int i = 0; i < 50; i++) {
			yield return new WaitForSeconds (0.01f);

			Fade_txt.GetComponent<UnityEngine.UI.Text> ().color += new Color (0f, 0f, 0f, 0.02f);

		}
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);

	}

	////////////////////////////////////////////
}
