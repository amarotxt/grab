using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController controller = null;
  
    // int faseAtual = 2;
    // Use this for initialization
    void Awake()
    {
        if (controller == null)
        {
            controller = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        // Debug.Log("antes inicio "+PlayerPrefs.GetInt("faseAtual"));

        if (PlayerPrefs.GetInt("faseAtual") <= 2)
        {
            PlayerPrefs.SetInt("faseAtual", 2);
        }
      
        DontDestroyOnLoad(this.gameObject);
    }

    public void IniciarJogo()
    {
        // Debug.Log("IniciarJogo"+PlayerPrefs.GetInt("faseAtual"));
        SceneManager.LoadScene(PlayerPrefs.GetInt("faseAtual"));

    }
    public void IniciarFase(int fase){
        SceneManager.LoadScene(fase);

    } 
    public void InfinitRun()
    {
        SceneManager.LoadScene(1);

    }

    public void NextFase()
    {
        PlayerPrefs.SetInt("faseAtual",PlayerPrefs.GetInt("faseAtual")+1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("faseAtual"));
    }

}
