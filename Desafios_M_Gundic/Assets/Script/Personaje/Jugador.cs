
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] public float vida = 5f;
    [SerializeField] private UnityEvent<string> OnTextChange;
    [SerializeField] private UnityEvent EsceneChange;

    private void Start()
    {
        OnTextChange.Invoke(vida.ToString());
    }

    public void ModificarVida(float puntos)
    {
        vida += puntos;
        OnTextChange.Invoke(vida.ToString());
        Debug.Log(EstasVivo());
    }


    private bool EstasVivo()
    {
        return vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }

        Debug.Log("Ganaste Esta Ronda!!!");
    }

    public void Update()
    {
        if (vida <= 0 || Input.GetKeyDown(KeyCode.R))
            { 
            
            EsceneChange.Invoke();

        }


    }
}