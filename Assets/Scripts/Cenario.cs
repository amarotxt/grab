using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cenario : MonoBehaviour {


	Transform player;
	// Update is called once per frame
	void Start (){
		player = GameObject.Find("Player").GetComponent<Transform>();
	}
	void Update () {
		//Seguir jogador
		if (player != null ){
			gameObject.transform.position = new Vector3 (0,0,player.transform.position.z);
		}	
	}
}
