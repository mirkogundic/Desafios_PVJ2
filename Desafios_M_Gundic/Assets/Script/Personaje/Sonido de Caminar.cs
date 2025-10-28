using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

public class SonidodeCaminar : MonoBehaviour
{
    private Saltar rayCast;
    private Mover movimientoHorizontal;
    private AudioSource miAudio;
    private Jugador jugador;

    private void Awake()
    {
        rayCast = GetComponent<Saltar>();
        movimientoHorizontal = GetComponent<Mover>();
        miAudio = GetComponent<AudioSource>();
        jugador = GetComponent<Jugador>();
    }

    private void ClipWalk()
    {
        if (rayCast.IsGrounded() && movimientoHorizontal.velocidadX != 0)
        {
            rayCast.CrearParticulas(0.2f);
            miAudio.PlayOneShot(jugador.PerfilJugador.CaminarSFX);
        }
    }


}
