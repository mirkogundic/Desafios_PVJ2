
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    [SerializeField] private UnityEvent<string> OnTextChange;

    private AudioSource miAudioSource;
    public GameObject activarEscena;
    public BarraVida barraDeVida;


    private void Awake()
    {

        activarEscena.gameObject.SetActive(true);
        miAudioSource = GetComponent<AudioSource>();

    }


    private void Start()
    {

        if (perfilJugador.Vida <= 0)
        {
            perfilJugador.ReiniciarPerfil();
        }

        barraDeVida.InicializarBarraVida(perfilJugador.Vida);
        OnTextChange.Invoke(perfilJugador.Vida.ToString());

    }

    public void ModificarVida(float puntos)
    {
        if (puntos <= -1)
        {
            miAudioSource.PlayOneShot(perfilJugador.DamageSFX);
        }
        perfilJugador.Vida += puntos;
        barraDeVida.CambiarVidaActual(perfilJugador.Vida);
        OnTextChange.Invoke(perfilJugador.Vida.ToString());
        Debug.Log(EstasVivo());
            
    }


    private bool EstasVivo()
    {
        return perfilJugador.Vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }

        Debug.Log("Ganaste Esta Ronda!!!");
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            { 
            QuitGame();
        }
        //Reseteamos lan Escene si muere
        if (perfilJugador.Vida <= 0)
        {
            ResetScene();
        }

    }
    public void ResetScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}