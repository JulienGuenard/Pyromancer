using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Garde_EnemyDetection_Scan : MonoBehaviour
{
	public GameObject GameS_GMB;
	public GameState GameS;

    [Header("Display")]
    public Material displayMaterial; // The material applied to the view cone.
    public bool drawDebug; // Will display raycasts if true.

    [Header("View parameters")]
    public float viewAngle = 75f; // How wide the view cone is.
    public float viewDistance = 10f; // How for goes the raycast.
    public LayerMask obstacleMask; // Which layers should the ray intersect with.

    [Header("Quality")]

    public int numberOfRays = 20; // The number of rays to send.
    public float updateFrequency = 0.05f; // How frequently to update the view cone (high value will run faster, but decrease how responsive the view cone is). 
    public bool liveUpdate = false; // If true, will update the mesh in real time if the view angle or the number of rays is changed.

    // Used to store mesh data

    Mesh sightMesh;
    Transform viewTransform;
    Transform meshTransform;
    Vector3[] rayDirections;
    Vector3[] points;

    // Used to detect changes to make to the mesh

    float previousViewAngle;
    int previousNumberOfRays;

    void OnEnable()
    {
		GameS_GMB = GameObject.Find ("rootScripts");
		GameS = GameS_GMB.GetComponent<GameState>();

        sightMesh = new Mesh();

        // Create sight object

        GameObject sightObject = new GameObject("ConeSight");
		sightObject.transform.parent = transform;
        (sightObject.AddComponent(typeof(MeshFilter)) as MeshFilter).mesh = sightMesh;
        (sightObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer).material = displayMaterial;
        meshTransform = sightObject.transform;

        // Store own transform for faster access

        viewTransform = transform;

        // Create base mesh

        CreateSightMesh();

        // Start scanning at set frequency

        StartCoroutine("Scan");
    }


    void OnDisable()
    {
        StopCoroutine("Scan");
    }

    IEnumerator Scan()
    {
        while (true)
        {
            meshTransform.position = viewTransform.position;
            meshTransform.rotation = viewTransform.rotation;

            if (liveUpdate && ((numberOfRays != previousNumberOfRays) || (viewAngle != previousViewAngle)))
                CreateSightMesh();

            UpdateSightMesh();

            yield return new WaitForSeconds(updateFrequency);
        }
    }

    private void CreateSightMesh()
    {
        // Clear the data if the mesh isn't new

        sightMesh.Clear();

        // Make sure to have a minimum number of rays

        numberOfRays = Mathf.Max(numberOfRays, 2);

        // Store data

        previousViewAngle = viewAngle;
        previousNumberOfRays = numberOfRays;

        // Prepare rays

        rayDirections = new Vector3[numberOfRays];
        float angleStart = -viewAngle * 0.5f;
        float angleStep = viewAngle / (numberOfRays - 1);
        for (int i = 0; i < numberOfRays; i++)
        {
            Matrix4x4 mat = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, angleStart + i * angleStep, 0), Vector3.one);
            rayDirections[i] = mat * Vector3.forward;
        }

        // Create base mesh

        points = new Vector3[numberOfRays + 1];
        for (int i = 1; i < numberOfRays + 1; i++)
        {
            points[i] = rayDirections[i - 1];
        }

        int[] indices = new int[(numberOfRays - 1) * 3];
        for (int i = 0; i < numberOfRays - 1; i++)
        {
            indices[i * 3 + 0] = 0;
            indices[i * 3 + 1] = i + 1;
            indices[i * 3 + 2] = i + 2;
        }

        sightMesh.vertices = points;
        sightMesh.uv = new Vector2[points.Length];
        sightMesh.triangles = indices;
    }
    
    private void UpdateSightMesh()
    {
        for (int i = 0; i < previousNumberOfRays; i++)
        {
            // Raycast data
            Vector3 currentDirection = viewTransform.TransformDirection(rayDirections[i]);
            float hitDistance = viewDistance;
            RaycastHit hit;

            // Do raycast
			if (GameS.GameEnd) {
				if (Physics.Raycast (viewTransform.position, currentDirection, out hit, viewDistance, obstacleMask)) {
				
					hitDistance = hit.distance;
					if (hit.transform.gameObject.tag == "Player" && transform.GetComponentInParent<Garde_Patrol> ().Etat != "Trouve") { //si le collider touché a pour tag Player, envoie un message de collision au premier enfant du 
                        transform.GetComponentInParent<Garde_Patrol> ().PoursuiteEvent = true;
					}

                    if (hit.transform.gameObject.tag == "Maison_Incendie" && transform.GetComponentInParent<Garde_Patrol>().Etat == "Poursuite")
                    { //si le collider touché a pour tag Player, envoie un message de collision au premier enfant du GameObject
                        transform.GetComponentInParent<Garde_Poursuite>().Etat = "Alerte";
                        transform.GetComponentInParent<Garde_Patrol>().Etat = "Alerte";
                    }
                    if (hit.transform.gameObject.tag == "Maison_Incendie") { //si le collider touché a pour tag Player, envoie un message de collision au premier enfant du GameObject
						transform.GetComponentInParent<Garde_EnemyDetection_DetectIncendie> ().SendMessage ("OnTriggerStay", hit.transform.gameObject.GetComponent<Collider> ());
					}


					if (hit.transform.gameObject.tag == "Garde" && transform.GetComponentInParent<Garde_Patrol> ().Etat == "Alerte" && hit.transform.gameObject.GetComponent<Garde_Patrol> ().Etat != "Poursuite") {
						hit.transform.gameObject.GetComponent<Garde_Patrol> ().Etat = "Alerte";
					}

                    if (hit.transform.gameObject.tag == "Garde" && hit.transform.gameObject.GetComponent<Garde_Patrol>().Etat == "Alerte" && transform.GetComponentInParent<Garde_Patrol>().Etat == "Poursuite")
                    {
                        transform.GetComponentInParent<Garde_Patrol>().Etat = "Alerte";
                    }

                    if (hit.transform.gameObject.tag == "Garde" && hit.transform.gameObject.GetComponent<Garde_Patrol> ().Etat == "Poursuite") {
						transform.GetComponentInParent<Garde_Patrol> ().PoursuiteEvent = true;
					}

                    // Transmissions d'état
                    if (hit.transform.gameObject.tag == "Garde")
                    {
                        Debug.Log("state of guard is." + transform.GetComponentInParent<Garde_Patrol>().Etat);
                        Debug.Log("other gard seen.");
                        if (transform.GetComponentInParent<Garde_Patrol>().Etat == "Alerte" && hit.transform.gameObject.GetComponent<Garde_Patrol>().Etat != "Alerte")
                        {
                            Debug.Log("Want to alert an other gard.");
                            hit.transform.gameObject.GetComponentInParent< Garde_EnemyDetection_DetectIncendie > ().SendMessage("OnTriggerStay", hit.transform.gameObject.GetComponent<Collider>());
                        }
                    }
                }
            }

            // Apply distance to point
            points[i+1] = rayDirections[i] * hitDistance;

            // Debug
            if(drawDebug)
                Debug.DrawRay(viewTransform.position, currentDirection * hitDistance, Color.red, updateFrequency);
        }

        // Update mesh data
        sightMesh.vertices = points;
        sightMesh.RecalculateBounds(); // on recalcule les bounds avant la normale 
        sightMesh.RecalculateNormals();
    }
}
