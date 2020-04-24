using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController controller = null;
    int parentPosition;
    int faseAtual = 2;
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
        parentPosition = 0;
       
        // Debug.Log("antes inicio "+PlayerPrefs.GetInt("faseAtual"));

        if (PlayerPrefs.GetInt("faseAtual") != 0)
        {
            // Debug.Log("inicio"+PlayerPrefs.GetInt("faseAtual"));
            faseAtual = faseAtual + PlayerPrefs.GetInt("faseAtual");
        }
        else
        {
            PlayerPrefs.SetInt("faseAtual", faseAtual);
        }
      
        DontDestroyOnLoad(this.gameObject);
    }

    public void IniciarJogo()
    {
        Debug.Log("IniciarJogo"+PlayerPrefs.GetInt("faseAtual"));
        SceneManager.LoadScene(PlayerPrefs.GetInt("faseAtual"));

    }
    public void InfinitRun()
    {
        SceneManager.LoadScene(1);

    }

    public void NextFase()
    {
        PlayerPrefs.SetInt("faseAtual", faseAtual++);
        SceneManager.LoadScene(faseAtual);

    }

}
