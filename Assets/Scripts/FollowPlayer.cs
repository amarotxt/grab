using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour{
	Player player;
	// Use this for initialization
	void Start () {
		player	= GameObject.Find ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z+player.speedZ);
	}
}
