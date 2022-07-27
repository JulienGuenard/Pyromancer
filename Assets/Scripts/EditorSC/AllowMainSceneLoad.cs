using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllowMainSceneLoad : MonoBehaviour {
    private AsyncOperation async;


    // Use this for initialization
    void Start() {}

    // Update is called once per frame
    void Update() {
	/*	if (Menu_Boutons.SceneName != null && ) {
			if (SceneManager.GetSceneByName("Level_Backend").isLoaded &&
				SceneManager.GetSceneByName(Menu_Boutons.SceneName).isLoaded)
				Destroy(gameObject);
	        if (SceneManager.GetSceneByName("Level_Backend").isLoaded &&
	            !SceneManager.GetSceneByName(Menu_Boutons.SceneName).isLoaded)
	            SceneManager.LoadScene(Menu_Boutons.SceneName, LoadSceneMode.Single);
				SceneManager.LoadSceneAsync("Level_Backend", LoadSceneMode.Additive);
	 	   }*/
		}
}
