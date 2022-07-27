#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.IO;
using System;

[ExecuteInEditMode]
public class SceneGUI : MonoBehaviour
{
	public bool abcd = true;

	public LightingDataAsset ActiveLight;

	bool ShowAide = false;

	public GUIStyle RectGardeStyle;
	public GUIStyle RectGardeStyle_2;

	public int Orientation = 0;

	Vector3 LastPosCam;

	GameObject[] objets = new GameObject [1];

	GameObject objet;

	public Texture[] toolbarStrings;

	public int toolbarInt = 0;

	static bool OneTime = true;
	static bool ShowGUI = true;

	public List<GameObject> iconobjet;

	void Start () {
		if (!Application.isPlaying) {
		EditorSceneManager.SaveScene (EditorSceneManager.GetActiveScene ());
		objets[0] = objet;
		}
	}

	void Update () {

		if (ShowGUI && OneTime) {
			OneTime = false;
			SceneView.onSceneGUIDelegate += OnSceneTool;
		}
		if (!ShowGUI && OneTime) {
			OneTime = false;
			SceneView.onSceneGUIDelegate -= OnSceneTool;
		}
	}

	[MenuItem("Window/Scene GUI/Enable")]
	public static void Enable()
	{
		ShowGUI = true;
		OneTime = true;
		Debug.Log("Scene GUI : Enabled");
	}

	[MenuItem("Window/Scene GUI/Disable")]
	public static void Disable()
	{
		ShowGUI = false;
		OneTime = true;
		Debug.Log("Scene GUI : Disabled");
	}

	static void ReadLineTest(int line_index, List<string> line)
	{
		Console.Out.WriteLine("\n==> Line {0}, {1} column(s)", line_index, line.Count);
		for (int i = 0; i < line.Count; i++)
		{
			Console.Out.WriteLine("Cell {0}: *{1}*", i, line[i]);
		}

	}

	void OnSceneTool(SceneView sceneview) {
		Handles.BeginGUI();

		foreach (GameObject garde in GameObject.FindGameObjectsWithTag("Garde_GMB")) {
			garde.GetComponent<Garde_Patrol> ().Call_LineRenderer ();
		}

		objets = Selection.gameObjects;

		GUI.Box (new Rect (10, 100, 220, 40), "     Garde Selection", RectGardeStyle);
		GUI.Box (new Rect (10, 140, 220, 40), "Evenement: " + (Garde_LineRenderer.ChosenGroupTraj + 1).ToString(), RectGardeStyle);
		GUI.Box (new Rect (10, 160, 220, 40), "Groupe Waypoint: " + (Garde_LineRenderer.ChosenTraj + 1).ToString (), RectGardeStyle);

		if (ShowAide) {

			GUI.Box (new Rect (300, 50, 220, 40), "** Création d'objet **\nCliquez sur une icone pour faire apparaître un objet sur la scène\n\n** Bouger un objet **\nFlèches directionnelles : Bouger l'objet\n4,5,6,8 : Bouger l'objet\n7,9 : Roter l'objet\n1,3 : Rescale l'objet\n\n** Générer un niveau **\nCliquer sur le bouton Générer un niveau, il ne sera pas intégré au jeu tout de suite avec le \nmenu mais vous pourrez le tester en playmode, n'oubliez pas de l'enregistrer dans le \ndossier Level\n\n** Trajectoires des gardes **\nUn garde a plusieurs trajectoire de déplacement, vous pouvez ajouter des point de patrouille \ndans l'inspecteur à droite et les placer ensuite sur la scène.\nGR_Routine = Evenement\nRoutine = Patrouille entre les points à l'intérieur de cette routine\n\n** Types d'évènements **\nEvenement (1) : Patrouille de départ\nEvenement (2) : Patrouille d'alerte\n(Note: si Evenement (2) contient 4 Routines, alors la patrouille d'alerte se déclenchera en \nfonction de la rotation du garde.\n\n** Placement des waypoints **\nF1,F2 : Choisir Evenement\n1,2,3,4 Alphanumériques : Choisir Routine", RectGardeStyle_2);
		}


		toolbarInt = GUI.Toolbar (new Rect (5, 5, 32 * toolbarStrings.Length, 32), toolbarInt, toolbarStrings);
		if (GUI.Button (new Rect (5, 40, 100, 45), "Generate Level")) {

			EditorSceneManager.SaveOpenScenes ();

			Scene NewScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
			EditorSceneManager.SaveScene (NewScene);

			EditorSceneManager.OpenScene (NewScene.path,OpenSceneMode.Single);

			RenderSettings.reflectionIntensity = 0.05f;
			UnityEditor.Lightmapping.lightingDataAsset = ActiveLight;

			GameObject objet1 = (GameObject)PrefabUtility.InstantiatePrefab (Resources.Load("Ressources/Gameplay/ROOT/rootScripts"));
			objet1.GetComponent<SceneGUI> ().StartCoroutine ("ReloadFunc");

			objet1 = (GameObject)PrefabUtility.InstantiatePrefab (Resources.Load("Ressources/Gameplay/ROOT/root"));
			objet1 = (GameObject)PrefabUtility.InstantiatePrefab (Resources.Load("Ressources/Gameplay/Terrain/Terrain"));
			objet1 = (GameObject)PrefabUtility.InstantiatePrefab (Resources.Load("Ressources/Gameplay/Joueur/GRP_Player"));
		}



		if (GUI.Button (new Rect (105, 40, 100, 45), "Aide")) {
			if (!ShowAide) {
				ShowAide = true;
			} else {
				ShowAide = false;
			}





		}

		if (toolbarInt != 999) {
			Vector3 PositionCreated = new Vector3 (Mathf.Round(UnityEditor.SceneView.lastActiveSceneView.pivot.x),Mathf.Round(UnityEditor.SceneView.lastActiveSceneView.pivot.y),Mathf.Round(UnityEditor.SceneView.lastActiveSceneView.pivot.z));
			objet = (GameObject)PrefabUtility.InstantiatePrefab(iconobjet[toolbarInt]);
			objet.transform.position = PositionCreated;
			objet.transform.rotation = iconobjet[toolbarInt].transform.rotation;
			objet.name = iconobjet [toolbarInt].name;
			Selection.activeGameObject = objet;
			SceneView sceneView = SceneView.lastActiveSceneView;
			toolbarInt = 999;
		}

		if (Event.current.keyCode == KeyCode.F1) {
			Garde_LineRenderer.ChosenGroupTraj = 0;
			Garde_LineRenderer.HasChanged = true;
		}
		if (Event.current.keyCode == KeyCode.F2) {
			Garde_LineRenderer.ChosenGroupTraj = 1;
			Garde_LineRenderer.HasChanged = true;
		}
		if (Event.current.keyCode == KeyCode.F3) {
			Garde_LineRenderer.ChosenGroupTraj = 2;
			Garde_LineRenderer.HasChanged = true;
		}


		if (Event.current.keyCode == KeyCode.Alpha1) {
			Garde_LineRenderer.ChosenTraj = 0;
			Garde_LineRenderer.HasChanged = true;
		}
		if (Event.current.keyCode == KeyCode.Alpha2) {
			SceneView sv = SceneView.sceneViews[0] as SceneView;
			sv.in2DMode = false;
			Garde_LineRenderer.ChosenTraj = 1;
			Garde_LineRenderer.HasChanged = true;
		}
		if (Event.current.keyCode == KeyCode.Alpha3) {
			Garde_LineRenderer.ChosenTraj = 2;
			Garde_LineRenderer.HasChanged = true;
		}
		if (Event.current.keyCode == KeyCode.Alpha4) {
			Garde_LineRenderer.ChosenTraj = 3;
			Garde_LineRenderer.HasChanged = true;
		}
		if (Event.current.keyCode == KeyCode.Alpha5) {
			Garde_LineRenderer.ChosenTraj = 4;
			Garde_LineRenderer.HasChanged = true;
		}
		if (Event.current.keyCode == KeyCode.Alpha6) {
			Garde_LineRenderer.ChosenTraj = 5;
			Garde_LineRenderer.HasChanged = true;
		}

		if (UnityEditor.SceneView.lastActiveSceneView.camera.transform.rotation.eulerAngles.y < 45 || UnityEditor.SceneView.lastActiveSceneView.camera.transform.rotation.eulerAngles.y > 315) {
			Orientation = 0;
		}
		if (UnityEditor.SceneView.lastActiveSceneView.camera.transform.rotation.eulerAngles.y < 315 && UnityEditor.SceneView.lastActiveSceneView.camera.transform.rotation.eulerAngles.y > 225) {
			Orientation = 1;
		}
		if (UnityEditor.SceneView.lastActiveSceneView.camera.transform.rotation.eulerAngles.y < 225 && UnityEditor.SceneView.lastActiveSceneView.camera.transform.rotation.eulerAngles.y > 135) {
			Orientation = 2;
		}
		if (UnityEditor.SceneView.lastActiveSceneView.camera.transform.rotation.eulerAngles.y < 135 && UnityEditor.SceneView.lastActiveSceneView.camera.transform.rotation.eulerAngles.y > 45) {
			Orientation = 3;
		}
		if (Event.current.type == EventType.KeyDown) {
			if (objets != null) {
				foreach (GameObject obj in objets) {
					if (obj != null && Event.current.keyCode == KeyCode.Keypad7) {
						obj.transform.rotation = Quaternion.Euler (obj.transform.rotation.eulerAngles.x, obj.transform.rotation.eulerAngles.y + 5, obj.transform.rotation.eulerAngles.z);
					}
					if (obj != null && Event.current.keyCode == KeyCode.Keypad9) {
						obj.transform.rotation = Quaternion.Euler (obj.transform.rotation.eulerAngles.x, obj.transform.rotation.eulerAngles.y - 5, obj.transform.rotation.eulerAngles.z);
					}

					if (obj != null && Event.current.keyCode == KeyCode.Keypad1) {
						if (obj.tag != "Limit") {
							obj.transform.localScale += new Vector3 (-0.5f, -0.5f, -0.5f);
						} else {
							obj.transform.localScale += new Vector3 (0f, 0f, -0.5f);
						}
					}
					if (obj != null && Event.current.keyCode == KeyCode.Keypad3) {
						if (obj.tag != "Limit") {
							obj.transform.localScale += new Vector3 (0.5f, 0.5f, 0.5f);
						} else {
							obj.transform.localScale += new Vector3 (0f, 0f, 0.5f);
						}
					}

					switch (Orientation) {
					case 0:

						if (obj != null && (Event.current.keyCode == KeyCode.DownArrow || Event.current.keyCode == KeyCode.Keypad5)) {	
							obj.transform.position += new Vector3 (0, 0, -1);
						}
						if (obj != null && (Event.current.keyCode == KeyCode.UpArrow || Event.current.keyCode == KeyCode.Keypad8)) {
							obj.transform.position += new Vector3 (0, 0, 1);
						}
						if (obj != null && (Event.current.keyCode == KeyCode.LeftArrow || Event.current.keyCode == KeyCode.Keypad4)) {
							obj.transform.position += new Vector3 (-1, 0, 0);
						}
						if (obj != null && (Event.current.keyCode == KeyCode.RightArrow || Event.current.keyCode == KeyCode.Keypad6)) {
							obj.transform.position += new Vector3 (1, 0, 0);
						}

						break;
					case 1:

						if (obj != null && (Event.current.keyCode == KeyCode.DownArrow || Event.current.keyCode == KeyCode.Keypad5)) {
							obj.transform.position += new Vector3 (1, 0, 0);
						}
						if (obj != null && (Event.current.keyCode == KeyCode.UpArrow || Event.current.keyCode == KeyCode.Keypad8)) {
							obj.transform.position += new Vector3 (-1, 0, 0);
						}
						if (obj != null && (Event.current.keyCode == KeyCode.LeftArrow || Event.current.keyCode == KeyCode.Keypad4)) {
							obj.transform.position += new Vector3 (0, 0, -1);
						}
						if (obj != null && (Event.current.keyCode == KeyCode.RightArrow || Event.current.keyCode == KeyCode.Keypad6)) {
							obj.transform.position += new Vector3 (0, 0, 1);
						}

						break;
					case 2:
						if (obj != null && (Event.current.keyCode == KeyCode.DownArrow || Event.current.keyCode == KeyCode.Keypad5)) {
							obj.transform.position += new Vector3 (0, 0, 1);
						}
						if (obj != null && (Event.current.keyCode == KeyCode.UpArrow || Event.current.keyCode == KeyCode.Keypad8)) {
							obj.transform.position += new Vector3 (0, 0, -1);
						}
						if (obj != null && (Event.current.keyCode == KeyCode.LeftArrow || Event.current.keyCode == KeyCode.Keypad4)) {
							obj.transform.position += new Vector3 (1, 0, 0);
						}
						if (obj != null && (Event.current.keyCode == KeyCode.RightArrow || Event.current.keyCode == KeyCode.Keypad6)) {
							obj.transform.position += new Vector3 (-1, 0, 0);
						}

						break;
					case 3:
						if (obj != null && (Event.current.keyCode == KeyCode.DownArrow || Event.current.keyCode == KeyCode.Keypad5)) {
							obj.transform.position += new Vector3 (-1, 0, 0);
						}
						if (obj != null && (Event.current.keyCode == KeyCode.UpArrow || Event.current.keyCode == KeyCode.Keypad8)) {
							obj.transform.position += new Vector3 (1, 0, 0);
						}
						if (obj != null && (Event.current.keyCode == KeyCode.LeftArrow || Event.current.keyCode == KeyCode.Keypad4)) {
							obj.transform.position += new Vector3 (0, 0, 1);
						}
						if (obj != null && (Event.current.keyCode == KeyCode.RightArrow || Event.current.keyCode == KeyCode.Keypad6)) {
							obj.transform.position += new Vector3 (0, 0, -1);
						}

						break;
					}
				}
			}
		}

		Handles.EndGUI();
	}

	public IEnumerator ReloadFunc () {
		EditorSceneManager.SaveScene (EditorSceneManager.GetActiveScene ());
		EditorSceneManager.OpenScene (EditorSceneManager.GetActiveScene ().path, OpenSceneMode.Single);
		yield return new WaitForSeconds (0.01f);
	}
}
#endif