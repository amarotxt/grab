using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

	int parentPosition;
	public GameObject PainelTutorial;
	void Start () {
		parentPosition = 0;

	}
	public void NextPainelTuroial(){
		parentPosition += 1;
		if (parentPosition >= 2 ) {
			parentPosition = 2;
		} 
		DesativarPaineisTutorial ();
		PainelTutorial.transform.GetChild (parentPosition).gameObject.SetActive (true);
	}
	public void BackPainelTuroial(){
		parentPosition -= 1;
		if (parentPosition <= 0 ) {
			parentPosition = 0;
		}
		DesativarPaineisTutorial ();
		PainelTutorial.transform.GetChild (parentPosition).gameObject.SetActive (true);
	}
	void DesativarPaineisTutorial(){
		int i = 0;
		for(i=0;i<=2; i++){
			PainelTutorial.transform.GetChild (i).gameObject.SetActive (false);
		}
	}
	public void SairTutorial(){
		SceneManager.LoadScene (1);
	}
}
