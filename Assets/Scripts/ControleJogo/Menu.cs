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
	public GameObject PainelFases;
	public GameObject Fases;
	public  Animator MenuAnimator;
	public Text distanciaPartida, recorde;
	public int faseToPlay;

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

	void setAllPaineistoFalse(){
		PainelFases.SetActive(false);
		PainelMenu.SetActive(false);
		PainelTutorial.SetActive(false);
	}
	public void IniciarFases()
    {
		setAllPaineistoFalse();
		PainelFases.SetActive(true);
	}
	public void Iniciar()
    {
		GameController.controller.IniciarFase(faseToPlay);
	
	}
	void DesativarTodasFasesView(){
     	foreach (Transform child in Fases.transform){
			child.gameObject.SetActive(false);
		 }
	}
	void ativarFase(string name){
		foreach (Transform child in Fases.transform){
			if (child.name == name)
			child.gameObject.SetActive(true);
		 }
	}
	public void SetarProximaFase(int numfase)
    {
		faseToPlay=numfase;
		MenuAnimator.SetTrigger("OtherAnimation");
		MenuAnimator.SetInteger("AnimationFase",numfase);
		DesativarTodasFasesView();
		// O numero da lista de fases no build da unit as fases estao com a ordem 1 a frente
		ativarFase("fase"+(faseToPlay-1));
		
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
