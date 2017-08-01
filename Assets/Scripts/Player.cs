using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public float speedZ;
	public float aceleration;
	GameObject player;
	Command MoveRight, MoveLeft, MoveUp, MoveDown, JumpLeft, JumpRight, JumpUp, JumpUpHigh;
	bool inGround, highJump, scale, jumpPress;

	void Start () {
		speedZ = 0.1f;
		aceleration = 1;
		inGround = false;
		scale = false;
		highJump = false;
		player = GameObject.Find ("Player");
		InvokeRepeating ("IncreaseSpeed",0.5f, 5.0f);
		MoveRight = new MoveRight ();
		MoveLeft = new MoveLeft ();
		MoveUp = new MoveUp ();
		MoveDown = new MoveDown ();
		JumpUp = new JumpUp ();
		JumpUpHigh = new JumpUpHigh ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && !scale) {
			MoveLeft.Execute (player);
			}

		if (Input.GetKey (KeyCode.RightArrow) ||Input.GetKey(KeyCode.D) && !scale) {
			MoveRight.Execute (player);
		}
			
		if ((Input.GetKey (KeyCode.UpArrow) ||Input.GetKey(KeyCode.W)) ) {
			MoveUp.Execute (player);
		}

		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
			MoveDown.Execute (player);
		}

		if (Input.GetKeyDown (KeyCode.Space) && inGround && !jumpPress) {
			jumpPress = true;
			if (highJump) {
				JumpUpHigh.Execute (player);
				highJump = false;
			} else {
				
				JumpUp.Execute (player);
			}

		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			jumpPress = false;
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
////////////////////////////////////////////////////////	
//		apagar depois
		if (collider.gameObject.CompareTag ("wall")) {
			inGround = false;
		} else {
			inGround = true;
		}
////////////////////////////////////////////////////////
	
		if (collider.gameObject.CompareTag ("scaleCub")) {
			deactvateGravity ();
			player.GetComponent<Rigidbody> ().Sleep ();
			scale = true;
		}
		if (collider.gameObject.CompareTag ("jumpHigh")) {
			highJump = true;
		}

	}
	void OnCollisionExit (Collision collider){
		inGround = false;
		if (collider.gameObject.CompareTag ("scaleCub")) {
			actvateGravity ();
			scale = false;
		}

	}
	void deactvateGravity(){
		player.GetComponent<Rigidbody> ().useGravity = false; 
	}
	void actvateGravity(){
		player.GetComponent<Rigidbody> ().useGravity = true; 
	}

}
