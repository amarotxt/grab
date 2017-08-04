//RETIRADO DE: https://www.youtube.com/watch?v=WTcOMTsnGuE&t=13s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour {

	public  GameObject gancho;
	private GameObject auxGancho;
	public GameObject target;

	public Camera m_camera;
	public LayerMask parede;

	public Transform dirDoClique;
	private Transform auxDirDoClique;
	private Vector3 posicaoMause;
	private Vector3 localDoClique;
	private Vector3 posMouse;

	private Quaternion olharParaDir;

	void Start(){
		auxGancho = Instantiate(gancho, transform.position, olharParaDir) as GameObject;
		Destroy (auxGancho);
	}
	// Update is called once per frame
	void FixedUpdate () {
		posMouse = Input.mousePosition;

//		posMouse.z = RaycastHit
//		posMouse = m_camera.ScreenToWorldPoint (posMouse);


		if (auxGancho == null) {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, parede)) {
					if (hit.collider != null) {
						
						posMouse.z = hit.collider.gameObject.transform.position.z;
						posMouse = m_camera.ScreenToWorldPoint (posMouse);
					

					}
				}

				auxDirDoClique = Instantiate (dirDoClique, posMouse, Quaternion.identity) as Transform;

				localDoClique = (auxDirDoClique.transform.position - transform.position).normalized;
				olharParaDir = Quaternion.LookRotation (localDoClique);

				auxGancho = Instantiate (gancho, transform.position, olharParaDir) as GameObject;
				Destroy (auxDirDoClique.gameObject);
			}
		}
		posicaoMause = Input.mousePosition;
		posicaoMause.z = Vector3.Distance(m_camera.transform.position,transform.position);
		target.transform.position = m_camera.ScreenToWorldPoint(posicaoMause);
	}
}
