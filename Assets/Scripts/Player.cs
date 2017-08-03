using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float speedZ;
	public float aceleration;
	public float forcabalanco;
	public LayerMask groundLayers;
	public Camera m_camera;
	public Text distance;

	GameObject player;
	Command MoveRight, MoveLeft, MoveUp, MoveDown, JumpLeft, JumpRight, JumpUp, JumpUpHigh;
	private bool highJump, scale, jumpPress, pendurado;
	private BoxCollider box;

	void Start () {
		
		speedZ =0.1f;
		aceleration = 1;
		scale = false;
		highJump = false;
		player = GameObject.Find ("Player");
		box = player.gameObject.GetComponent<BoxCollider> ();
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
		distance.text = player.transform.position.z.ToString("0.00"); 
		if (m_camera.gameObject.transform.position.z > transform.position.z) {
			PlayerPrefs.SetFloat ("distanciaPartida", transform.position.z);
			if (PlayerPrefs.GetFloat ("distanciaPartida") >= PlayerPrefs.GetFloat ("recorde")) {
				PlayerPrefs.SetFloat ("recorde", player.transform.position.z);
			}
			SceneManager.LoadScene (0);

		}

		pendurado = Gancho.cordaColidiu;
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			MoveLeft.Execute (player);
		}
		else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && !IsGrounded() && pendurado){
			player.GetComponent<Rigidbody> ().AddRelativeForce(forcabalanco*transform.right*-1);
		}

		if (Input.GetKey (KeyCode.RightArrow) ||Input.GetKey(KeyCode.D) ) {
			MoveRight.Execute (player);
		}else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && !IsGrounded() && pendurado){
			player.GetComponent<Rigidbody> ().AddRelativeForce(forcabalanco*transform.right*1);
		}

		if ((Input.GetKey (KeyCode.UpArrow) ||Input.GetKey(KeyCode.W)) && scale ) {
			MoveUp.Execute (player);
		}

		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S) && scale) {
			MoveDown.Execute (player);
		}

		if (Input.GetKeyDown (KeyCode.Space) && (IsGrounded() || scale) && !jumpPress) {
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
		if (speedZ > 1) {
			CancelInvoke();
		}	

		if(player.GetComponent<Rigidbody>().velocity.z > 25){
			player.GetComponent<Rigidbody> ().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x,GetComponent<Rigidbody>().velocity.y,25);

		} 
	}


	void OnCollisionEnter (Collision collider){
	
		if (collider.gameObject.CompareTag ("scaleCub")) {
			deactvateGravity ();
			player.GetComponent<Rigidbody> ().Sleep ();
			scale = true;
		}
		if (collider.gameObject.CompareTag ("jumpHigh")) {
			highJump = true;
		}
		if (collider.gameObject.CompareTag ("Finish")) {
			PlayerPrefs.SetFloat ("distanciaPartida", player.transform.position.z);
			if (PlayerPrefs.GetFloat ("distanciaPartida") >= PlayerPrefs.GetFloat ("recorde")) {
				PlayerPrefs.SetFloat ("recorde", player.transform.position.z);
			}
			SceneManager.LoadScene (0);
		}

	}
	void OnCollisionExit (Collision collider){
		
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
	void IncreaseSpeed(){

		speedZ += (Time.deltaTime * aceleration);
	}
	private bool IsGrounded()
	{
		RaycastHit ray;
		return Physics.Raycast(transform.position,-transform.up,out ray, 1.5f);
	}

}
