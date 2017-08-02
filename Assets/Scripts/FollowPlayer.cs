using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour{
	GameObject player;
	Vector3 positionPlay;
	Vector3 positionFollow;
	// Use this for initialization
	void Start () {
		player	= GameObject.Find ("Player");
		positionFollow = new Vector3 (0,0,0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		positionPlay = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
		positionFollow = new Vector3 (positionPlay.x, positionPlay.y,positionFollow.z+player.gameObject.GetComponent<Player> ().speedZ);
		gameObject.transform.position = positionFollow;
	}


}
