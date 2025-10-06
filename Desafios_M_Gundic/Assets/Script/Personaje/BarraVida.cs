using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Image rellenoBarraVida;
    private Jugador playerController;
    private float vidaMaxima;
    void Start()
    {
        playerController = GameObject.Find("Jugador").GetComponent<Jugador>();
        vidaMaxima = playerController.vida;
    }

    void Update()
    {
        rellenoBarraVida.fillAmount = playerController.vida / vidaMaxima;
    }
}
