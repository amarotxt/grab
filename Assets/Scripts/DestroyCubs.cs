using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCubs : MonoBehaviour {
	
	void OnCollisionEnter (Collision collider){
		if (collider.gameObject.CompareTag("end")){
			this.gameObject.SetActive(false);
		}
	}
}
