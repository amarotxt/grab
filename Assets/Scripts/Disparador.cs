//RETIRADO DE: https://www.youtube.com/watch?v=WTcOMTsnGuE&t=13s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour {

	public  GameObject gancho;
	private GameObject auxGancho;

	public Camera m_camera;

	public Transform dirDoClique;
	private Transform auxDirDoClique;

	private Vector3 localDoClique;
	private Vector3 posMouse;

	private Quaternion olharParaDir;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		posMouse = Input.mousePosition;
		Debug.Log (posMouse);



//		posMouse.z = RaycastHit
//		posMouse = m_camera.ScreenToWorldPoint (posMouse);


		if (auxGancho == null) {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider != null) {
						Debug.DrawRay ();
						posMouse.z = hit.collider.gameObject.transform.position.z;
						posMouse = m_camera.ScreenToWorldPoint (posMouse);
						Debug.Log (posMouse);

					}
				}

				auxDirDoClique = Instantiate (dirDoClique, posMouse, Quaternion.identity) as Transform;
				Debug.Log (localDoClique);

				localDoClique = (auxDirDoClique.transform.position - transform.position).normalized;
				Debug.Log (localDoClique);
				olharParaDir = Quaternion.LookRotation (localDoClique);

				auxGancho = Instantiate (gancho, transform.position, olharParaDir) as GameObject;
				Destroy (auxDirDoClique.gameObject);
			}
		}
	}
}
