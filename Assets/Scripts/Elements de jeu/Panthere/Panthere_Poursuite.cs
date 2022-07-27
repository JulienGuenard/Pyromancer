using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panthere_Poursuite : Etourdissable {

	[HideInInspector]
	public UnityEngine.AI.NavMeshAgent agent;

	Vector3 destination;
	public Vector3 PointFuite;

	bool FuiteBool = false;

	public GameObject Cible;

	public float Speed;
	public float SpeedSave;

	// Use this for initialization
	void Start () {

		SpeedSave = Speed;

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		PointFuite = transform.position + 50 * Vector3.forward;
	}
	
	// Update is called once per frame
	void Update () {

        agent.speed = Speed - EtourdissementSpeed;

        if (Cible != null && !FuiteBool) {
			destination = Cible.transform.position;
			agent.SetDestination (destination);
		}
	}

	public void Poursuite () {
		
	}

	public void Fuite () {
		FuiteBool = true;
		agent.SetDestination (PointFuite);
	}

}
