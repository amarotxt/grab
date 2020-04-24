using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
	public GameObject PainelMenu;
	public GameObject PainelTutorial;
	public Text distanciaPartida, recorde;
	int parentPosition;
	// Use this for initialization
	void Start () {
		parentPosition = 0;
		distanciaPartida.text = PlayerPrefs.GetFloat ("distanciaPartida").ToString("0.00");
		recorde.text = PlayerPrefs.GetFloat ("recorde").ToString("0.00");
	}

    public void IniciarTutorial(){
		PainelMenu.SetActive(false);
		PainelTutorial.SetActive (true);

	}

	public void IniciarJogo()
    {
		GameController.controller.IniciarJogo();
	}
    public void InfinitRun()
    {
        GameController.controller.InfinitRun();

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
		PainelTutorial.gameObject.SetActive (false);
		PainelMenu.gameObject.SetActive (true);
	}
}
