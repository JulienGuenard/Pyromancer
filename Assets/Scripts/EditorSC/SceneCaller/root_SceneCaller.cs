#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class root_SceneCaller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!Application.isPlaying) {

			EditorSceneManager.OpenScene("Assets/1. Scenes/BackEnd/Level_Backend.unity", OpenSceneMode.Additive);

		}
	}
}
#endif