using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progresion : MonoBehaviour
{

    [SerializeField]
    private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    public void GanarExperiencia(int nuevaExperiencia)
    {
        perfilJugador.Experiencia += nuevaExperiencia;

        if (perfilJugador.Experiencia >= perfilJugador.ExperienciaProximoNivel)
        {
            SubirNivel();
        }
    }

    private void SubirNivel()
    {
        perfilJugador.Nivel++;
        perfilJugador.Experiencia -= perfilJugador.ExperienciaProximoNivel;
        perfilJugador.ExperienciaProximoNivel += perfilJugador.EscalarExperiencia; // Aumenta la experiencia necesaria para el siguiente nivel

        // Aqu� puedes agregar l�gica adicional para mejorar las estad�sticas del jugador, desbloquear habilidades, etc.
    }
}