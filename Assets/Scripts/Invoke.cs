using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke : MonoBehaviour {
	public GameObject grabCub, jumpHigh, notGrab, scaleCub;   
	int randomCub;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateCubs", 0.1f,1f);
	}
	void CreateCubs (){
		randomCub = Random.Range (0, 100);
		GameObject cub;
//		Instantiate (grabCub, new Vector3(this.transform.position.x+Random.Range(-10,10),this.transform.position.y+Random.Range(-10,10),this.transform.position.z),Quaternion.identity);

		if (randomCub >= 11 && randomCub <= 40){
			cub = Instantiate (grabCub, new Vector3(this.transform.position.x+Random.Range(-14,14),this.transform.position.y+Random.Range(-10,10),this.transform.position.z),Quaternion.identity);
			cub.transform.localScale = new Vector3 (Random.Range(1f,10f),Random.Range(0.1f,15),Random.Range(5,30));

		}
		if (randomCub >= 41 && randomCub <= 60){
			cub = Instantiate (jumpHigh, new Vector3(this.transform.position.x+Random.Range(-14,14),this.transform.position.y+Random.Range(-10,0),this.transform.position.z),Quaternion.identity);
			cub.transform.localScale = new Vector3 (Random.Range(2f,10f),Random.Range(1f,4f),Random.Range(5,30));

		}
		if (randomCub >= 61 && randomCub <= 80){
			cub = Instantiate (notGrab, new Vector3(this.transform.position.x+Random.Range(-14,14),this.transform.position.y+Random.Range(-10,0),this.transform.position.z),Quaternion.identity);
			cub.transform.localScale = new Vector3 (Random.Range(2f,10f),Random.Range(2f,15f),Random.Range(5,30));

		}
		if (randomCub >= 81){
			cub = Instantiate (scaleCub, new Vector3(this.transform.position.x+Random.Range(-14,14),this.transform.position.y+Random.Range(-10,0),this.transform.position.z),Quaternion.identity);
			cub.transform.localScale = new Vector3 (Random.Range(0.1f,3f),Random.Range(2f,15f),Random.Range(5,30));

		}



	}
	

}
