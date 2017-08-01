using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public float speedZ;
	public float aceleration;
	GameObject player;
	Command MoveRight, MoveLeft, MoveUp, MoveDown, JumpLeft, JumpRight, JumpUp, JumpUpHigh;
	bool inGround;

	void Start () {
		speedZ = 0.1f;
		aceleration = 1;
		inGround = false;
		player = GameObject.Find ("Player");
		InvokeRepeating ("IncreaseSpeed",0.5f, 5.0f);
		MoveRight = new MoveRight ();
		MoveLeft = new MoveLeft ();
		JumpUp = new JumpUp ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			MoveLeft.Execute (player);
		}
		if (Input.GetKey (KeyCode.RightArrow) ||Input.GetKey(KeyCode.D)) {
			MoveRight.Execute (player);
		}
		if (Input.GetKeyDown(KeyCode.Space) && inGround){
			JumpUp.Execute(player);
		}

		gameObject.transform.Translate (0,0,speedZ);
		if (speedZ > 5) {
			CancelInvoke();
		}	
	}

	void IncreaseSpeed(){
		speedZ += (Time.deltaTime * aceleration);
	}


	void OnCollisionEnter (Collision collider){
		inGround = true;
		if (collider.gameObject.CompareTag ("scaleCub")) {
			deactvateGravity ();
		}

	}
	void OnCollisionExit (Collision collider){
		inGround = false;
		if (collider.gameObject.CompareTag ("scaleCub")) {
			deactvateGravity ();
		}

	}
	void deactvateGravity(){
		player.GetComponent<Rigidbody> ().useGravity = false; 
	}
	void actvateGravity(){
		player.GetComponent<Rigidbody> ().useGravity = true; 
	}

}
