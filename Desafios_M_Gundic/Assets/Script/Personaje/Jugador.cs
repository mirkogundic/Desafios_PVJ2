
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    [SerializeField] private UnityEvent<string> OnTextChange;
    [SerializeField] private UnityEvent EsceneChange;

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

    public void Update()
    {
        if (perfilJugador.Vida <= 0 || Input.GetKeyDown(KeyCode.R))
            { 
            
            EsceneChange.Invoke();

        }


    }
}