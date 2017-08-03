using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	public GameObject PainelMenu;
	public GameObject PainelTutorial;
	public Text distanciaPartida, recorde;

	// Use this for initialization
	void Start () {
		distanciaPartida.text = PlayerPrefs.GetFloat ("distanciaPartida").ToString("0.00");
		recorde.text = PlayerPrefs.GetFloat ("recorde").ToString("0.00");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void IniciarJogo(){
		SceneManager.LoadScene (1);

	}
}
