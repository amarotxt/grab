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

	Command MoveRight, MoveLeft, MoveUp, MoveDown, JumpLeft, JumpRight, JumpUp, JumpUpHigh, GoDown;
	private bool highJump, scale, canJump, pendurado;
	private BoxCollider box;

	private IEnumerator coroutine;

	void Start () {

		if (PlayerPrefs.GetInt ("tutorial") == 0){
			PlayerPrefs.SetInt ("tutorial", 1);	
			SceneManager.LoadScene (2);
		}


		speedZ =0.1f;
		aceleration = 1;
		scale = false;
		highJump = false;
		canJump = true;
		player = GameObject.Find ("Player");
		box = player.gameObject.GetComponent<BoxCollider> ();
		InvokeRepeating ("IncreaseSpeed",0.5f, 5.0f);
		MoveRight = new MoveRight ();
		MoveLeft = new MoveLeft ();
		MoveUp = new MoveUp ();
		MoveDown = new MoveDown ();
		JumpUp = new JumpUp ();
		JumpUpHigh = new JumpUpHigh ();
		GoDown = new GoDown ();
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

		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S) && !scale) {
			GoDown.Execute (player);
		}

		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S) && scale) {
			MoveDown.Execute (player);
		}

		if (Input.GetKeyDown (KeyCode.Space) && (IsGrounded() || scale) && canJump) {
			if (highJump) {
				JumpUpHigh.Execute (player);
				highJump = false;
			} else {

				JumpUp.Execute (player);
			}

		}


		gameObject.transform.Translate (0,0,speedZ);
		// Debug.Log(speedZ);	
		// if (speedZ > 1) {
		// 	CancelInvoke();
		// }	

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
		if (collider.gameObject.CompareTag ("notJump")) {
			canJump = false;
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
		if (collider.gameObject.CompareTag ("notJump")) {
			canJump = true;
		}
		if (collider.gameObject.CompareTag ("scaleCub")) {
			actvateGravity ();
			scale = false;
		}
		if (collider.gameObject.CompareTag ("jumpHigh")) {
			highJump = false;
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
//	public void calcularVelocidade(){
//		if ((float)Math.Log (pontuacao, 2) % 2 == 0 || (float)Math.Log (pontuacao, 2) % 2 == 1) {
//			velocidade = (float)Math.Log (pontuacao, 2) ;
//		}
//	}
	private bool IsGrounded()
	{
		return Physics.CheckBox (GetComponent<Collider>().bounds.center,new Vector3(0.2f,1f,0.2f), Quaternion.identity, groundLayers);

	}

}
