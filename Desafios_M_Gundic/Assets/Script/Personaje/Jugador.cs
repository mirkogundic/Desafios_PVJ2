
using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        OnTextChange.Invoke(perfilJugador.Vida.ToString());
    }

    public void ModificarVida(float puntos)
    {
        perfilJugador.Vida += puntos;
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