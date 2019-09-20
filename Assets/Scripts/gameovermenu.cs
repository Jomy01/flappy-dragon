using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameovermenu : MonoBehaviour
{

    public Text textoHighScore;

    // Use this for initialization

    void Start()
    {
        textoHighScore.text = "MAXIMA \n PUNTUACION: " + PlayerPrefs.GetInt("highscore").ToString();
    }
    public void Jugar()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Salir()
    {
        SceneManager.LoadScene("Menu");
    }


}
