//RETIRADO DE: https://www.youtube.com/watch?v=WTcOMTsnGuE&t=13s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{

    public GameObject gancho;
    private GameObject auxGancho;
    public GameObject target;

    public Camera m_camera;
    public Transform dirDoClique;
    private Vector3 posicaoMause;
    private Vector3 localDoClique;
    private Vector3 posMouse;

    private Quaternion olharParaDir;

    void Start()
    {
		gancho = Instantiate(gancho, new Vector3(0, 0, 0), Quaternion.identity);
		dirDoClique = Instantiate(dirDoClique, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
        gancho.SetActive(false);
        dirDoClique.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        posMouse = Input.mousePosition;

        //		posMouse.z = RaycastHit
        //		posMouse = m_camera.ScreenToWorldPoint (posMouse);


        // if (auxGancho == null) {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider != null)
                {

                    posMouse.z = hit.collider.gameObject.transform.position.z;
                    posMouse = m_camera.ScreenToWorldPoint(posMouse);


                }

                dirDoClique.gameObject.SetActive(true);
                dirDoClique.position = posMouse;
                dirDoClique.rotation = Quaternion.identity;
                localDoClique = (dirDoClique.position - transform.position).normalized;
                olharParaDir = Quaternion.LookRotation(localDoClique);

            }
            // Debug.Log(dirDoClique.gameObject.activeInHierarchy);
            if (dirDoClique.gameObject.activeInHierarchy == true)
            {
				
                gancho.transform.position = transform.position;
                gancho.transform.rotation = olharParaDir;
				gancho.SetActive(true);
				
                dirDoClique.gameObject.SetActive(false);

            }
        }
        // if (Input.GetMouseButtonUp (0) && gancho.gameObject.activeInHierarchy == true) {
        // 	gancho.gameObject.SetActive(false);			
        // }
        posicaoMause = Input.mousePosition;
        posicaoMause.z = Vector3.Distance(m_camera.transform.position, transform.position);

        target.transform.position = m_camera.ScreenToWorldPoint(posicaoMause);
    }
	
}
