using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour{
	GameObject player;
	Vector3 positionPlay;
	Vector3 positionFollow;
	float distanciaCameraPlayer;
	// Use this for initialization
	void Start () {
		// player	= GameObject.FindWithTag ("Player");
		player	= GameObject.Find ("Player");
		positionFollow = new Vector3 (0,0,0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (player != null) {
			distanciaCameraPlayer = Vector3.Distance (transform.position, player.transform.position);

			positionPlay = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);

			if (distanciaCameraPlayer > 2 && (player.transform.position.z > transform.position.z)) {
				positionFollow = new Vector3 (positionPlay.x, positionPlay.y, (positionFollow.z + player.gameObject.GetComponent<Player> ().speedZ) + (positionPlay.z - positionFollow.z));
			} else {
				// positionFollow = new Vector3 (positionPlay.x, positionPlay.y, (positionFollow.z + player.gameObject.GetComponent<Player> ().speedZ) + (positionPlay.z - positionFollow.z));
				positionFollow = new Vector3 (positionPlay.x, positionPlay.y, (positionFollow.z + player.gameObject.GetComponent<Player> ().speedZ));
			}
			gameObject.transform.position = positionFollow;
		} else {
			SceneManager.LoadScene (0);
		}
	}


}
