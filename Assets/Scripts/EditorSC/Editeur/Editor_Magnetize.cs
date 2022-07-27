using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Editor_Magnetize : MonoBehaviour {
	
	[Header ("Permet de fixer la position y des objets", order=0)]
	[Header ("ci-dessous par rapport au terrain.", order=1)]
	[Space (20, order=2)]

	public float Y_Totem = 1;
	public float Y_Brasero = 0.25f;
	public float Y_Maison = 0;
	public float Y_Garde_GMB = 0.8f;
	public float Y_GRP_Player = 0.5f;
	public float Y_Panthere = 0;
	public float Y_Dummy = 3f;
	public float Y_Plante = 0;
	public float Y_Vase = 0;
	public float Y_Broussaille = 0.5f;
	public float Y_Water = 0.4f;
	public float Y_Barque = 0.4f;
	public float Y_Limit = 1;
	public float Y_Waypoint = 0;
	public float Y_Exit = 0.5f;

	public List<string> TagUsed;

	float yMap = 0;
	float yGMBMap = 0;
	float Y_Obj = 0;

	GameObject GMB_Terrain;
	Terrain GameTerrain;

	//////////////////////////////////////////////////

	void Update () {

		if (!Application.isPlaying) {
			if (GMB_Terrain == null) {
				if (GameObject.Find ("Terrain") != null) {
					GMB_Terrain = GameObject.Find ("Terrain");
					GameTerrain = GMB_Terrain.GetComponent<Terrain> ();
					yGMBMap = GMB_Terrain.transform.position.y;
				}
			} else {

				for (int i = 0; i < TagUsed.Count; i++) {
					
					foreach (GameObject obj in GameObject.FindGameObjectsWithTag(TagUsed[i])) {
					Magnetize (obj);
				}
			}
		}
	}
}

	void Magnetize (GameObject obj) {
		yMap = GameTerrain.SampleHeight (obj.transform.position);
		Y_Obj = (float)this.GetType ().GetField ("Y_" + obj.tag).GetValue (this);
		obj.transform.position = new Vector3 (obj.transform.position.x, yMap + Y_Obj + yGMBMap, obj.transform.position.z);
	}
}
