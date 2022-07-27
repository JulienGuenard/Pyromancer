using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_Boutons : MonoBehaviour {

	public GameObject MainEcran;
    public GameObject SelectEcran;
    public Animator anim;
    private AsyncOperation async;
    static public string SceneName;


    public void Jouer () { // Lorsque l'on clique sur Jouer, va au niveau 1
		MainEcran.SetActive (false);
		SelectEcran.SetActive (true);
	}

	public void Quitter () { // Lorsque l'on clique sur Quitter, quitte l'application
		Application.Quit ();
	}

	////////////////////////////////////////

	public void LevelSelect (string SceneName) { // Lorsque l'on clique sur le premier level, va au niveau 1
	    Menu_Boutons.SceneName = SceneName;
     //   SceneManager.LoadSceneAsync("Level_Backend", LoadSceneMode.Single);
		SceneManager.LoadScene(Menu_Boutons.SceneName, LoadSceneMode.Single);
		SceneManager.LoadSceneAsync("Level_Backend", LoadSceneMode.Additive);
	}

    public void SetState (string state) { // Lorsque l'on clique Retour, on retourne à l'écran précédent
        anim.SetTrigger("Deactivate");
        anim.SetTrigger(state);
    }
}
