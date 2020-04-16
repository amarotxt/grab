using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke : MonoBehaviour {
	public PoolObject grabCub, jumpHigh, notJump, scaleCub;   
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
			cub = grabCub.GetPooledObject();
			// Instantiate (grabCub, new Vector3(this.transform.position.x+Random.Range(-14,14),this.transform.position.y+Random.Range(-10,10),this.transform.position.z),Quaternion.identity);
			cub.transform.position = new Vector3(this.transform.position.x+Random.Range(-14,14),this.transform.position.y+Random.Range(-10,10),this.transform.position.z);
			cub.transform.localScale = new Vector3 (Random.Range(2f,10f),Random.Range(2f,15),Random.Range(5,30));
			cub.SetActive(true);
		}
		if (randomCub >= 41 && randomCub <= 60){
			cub = jumpHigh.GetPooledObject();
			// Instantiate (grabCub, new Vector3(this.transform.position.x+Random.Range(-14,14),this.transform.position.y+Random.Range(-10,10),this.transform.position.z),Quaternion.identity);
			cub.transform.position = new Vector3(this.transform.position.x+Random.Range(-14,14),this.transform.position.y+Random.Range(-10,10),this.transform.position.z);
			cub.transform.localScale = new Vector3 (Random.Range(2f,10f),Random.Range(2f,15),Random.Range(5,30));
			cub.SetActive(true);
		}
		if (randomCub >= 61 && randomCub <= 80){
			cub = notJump.GetPooledObject();
			// Instantiate (grabCub, new Vector3(this.transform.position.x+Random.Range(-14,14),this.transform.position.y+Random.Range(-10,10),this.transform.position.z),Quaternion.identity);
			cub.transform.position = new Vector3(this.transform.position.x+Random.Range(-14,14),this.transform.position.y+Random.Range(-10,10),this.transform.position.z);
			cub.transform.localScale = new Vector3 (Random.Range(2f,10f),Random.Range(2f,15),Random.Range(5,30));
			cub.SetActive(true);
		}
		if (randomCub >= 81){
			cub = scaleCub.GetPooledObject();
			// Instantiate (grabCub, new Vector3(this.transform.position.x+Random.Range(-14,14),this.transform.position.y+Random.Range(-10,10),this.transform.position.z),Quaternion.identity);
			cub.transform.position = new Vector3(this.transform.position.x+Random.Range(-14,14),this.transform.position.y+Random.Range(-10,10),this.transform.position.z);
			cub.transform.localScale = new Vector3 (Random.Range(2f,10f),Random.Range(2f,15),Random.Range(5,30));
			cub.SetActive(true);
		}
	}
	

}
