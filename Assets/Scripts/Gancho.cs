﻿//RETIRADO DE: https://www.youtube.com/watch?v=WTcOMTsnGuE&t=13s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gancho : MonoBehaviour {

	public float velLancar;
	public float tamanhoCorda;
	public float forcaCorda;
	public float peso;

	private GameObject player;
	private Rigidbody corpoRigido;
	private SpringJoint efeitoCorda;

	private float distanciaDoPlayer;

	private bool atirarCorda;
	private bool cordaColidiu;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		corpoRigido = GetComponent<Rigidbody> ();
		efeitoCorda = player.GetComponent<SpringJoint> ();

		atirarCorda = true;
		cordaColidiu = false;
	}
	
	// Update is called once per frame
	void Update () {
		distanciaDoPlayer = Vector3.Distance (transform.position, player.transform.position);

		if (Input.GetMouseButtonDown (0)) {
			atirarCorda = false;
		}

		if (atirarCorda) {
			AtirarGancho ();
		} else {
			RecolherGancho ();
		}

		GetComponent<LineRenderer> ().SetPosition (0, player.transform.position);
		GetComponent<LineRenderer> ().SetPosition (1, transform.position);
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.name != "Player") {
			cordaColidiu = true;
		}
	}

	public void AtirarGancho(){
		if (distanciaDoPlayer <= tamanhoCorda) {
			if (!cordaColidiu) {
				transform.Translate (0, 0, velLancar * Time.deltaTime);
			} else {
				efeitoCorda.connectedBody = corpoRigido;
				efeitoCorda.spring = forcaCorda;
				efeitoCorda.damper = peso;
			}
		}

		if (distanciaDoPlayer > tamanhoCorda) {
			atirarCorda = false;
		}
	}

	public void RecolherGancho(){
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, 25*Time.deltaTime);

		if (distanciaDoPlayer <= 2) {
			Destroy (gameObject);
		}
	}
}
