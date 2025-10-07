using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Image rellenoBarraVida;
    private PerfilJugador perfilJugador;
    private float vidaMaxima;
    void Start()
    {
        vidaMaxima = perfilJugador.Vida;
    }

    void Update()
    {
        rellenoBarraVida.fillAmount = perfilJugador.Vida / vidaMaxima;
    }
}
