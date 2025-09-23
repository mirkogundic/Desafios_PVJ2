using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curar : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] int puntos = 1;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Jugador jugador = other.GetComponent<Jugador>();
            jugador.ModificarVida(puntos);
            Debug.Log(" PUNTOS DE VIDA SUMADOS AL JUGADOR " + puntos);
        }
    }
}