using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player_controller : MonoBehaviour
{
    //declaracion de variables
    public float potenciaSalto;
    public GameObject GameOverMenu;
    public GameObject fd_muerto;
    public Text puntuacion;
    Rigidbody2D myRigidbody;
    //añadimos audio
    AudioSource emisorAudio;
    //para añadir el clip de audio en unity
    public AudioClip sonidoSalto;
    public AudioClip sonidoPasoobstaculos;
    public AudioClip sonidoMuerte;
    public GameObject prefabBolafuego;

    //para intetnar cambiar el sprite
    public Animator animator;
    bool vivo = true;


    //para emitir sonidos con emisor audio usar emisor.audio.playoneshot(nombresonido)
    int puntos = 0;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        emisorAudio = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        // si presionamos la tecla espacio o tocamos la pantalla 1 vez
        if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began) && vivo == true)
        {
            Vector2 newVelocity;

            newVelocity = Vector2.up * potenciaSalto;
            //sin el *10f seria lo mismo que newVelocity.x = 0.0f; y newVelocity.y = 1.0f;
            //si pones += newVelocity al dejar presionado el espacio salta más
            myRigidbody.velocity = newVelocity;
            //que suene el efecto de sonido al saltar
            emisorAudio.PlayOneShot(sonidoSalto);

        }
        //para que dispare una bola de fuego
        if (Input.GetKeyDown(KeyCode.W) && vivo == true)
        {
            Instantiate(prefabBolafuego, transform.position, Quaternion.identity);

        }


    }
    // esto es cuando ocurre algo especial->chocar
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "muerte")
        {
            emisorAudio.PlayOneShot(sonidoMuerte);
            //para cambiar el icono cuando muere?
            //fd_muerto.SetActive(true);

            //cambiar sprite
            //fd_muerto.transform.position
            //void muerte()
            //{
            //  Rigidbody fd_muerto = (Rigidbody)Instantiate(player_2, transform.position, transform.rotation);
            //fd_muerto.velocity = transform.forward * 1.0f;
            //}

            //qué queremos hacer cuando choque
            //Destroy(gameObject);


            //para intetnar cambiar el sprite


            animator.SetBool("estamuerto", true);
            vivo = false;





            //para que se active el memnu gameover
            GameOverMenu.SetActive(true);

            //para guardar la puntuacion



        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "moneda")
        {
            //sonido paso obstaculo
            emisorAudio.PlayOneShot(sonidoPasoobstaculos);
            Destroy(other.gameObject);
            puntos++;
            if (puntuacion != null)
            {
                puntuacion.text = puntos.ToString();
            }
            else
            {
                print(puntos);
            }
        }




        if (puntos > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", puntos);
        }
        //para ver si funciona ese highscore
        print(PlayerPrefs.GetInt("highscore"));
    }

    // private void OnTriggerEnter2D(Collider2D other)
    //{
    //  Destroy(other.gameObject);
    //score++;
    //if (scoreText != null)
    //{
    //  scoreText.text = score.ToString();
    //}
    //else
    //{
    //    print(score);
    //}
}
