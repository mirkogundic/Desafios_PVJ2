using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask groundLayer;

    [Header("Salto Regulable")]
    [Range(0, 1)] [SerializeField] private float multiplicadorCancelarSalto;
    [SerializeField] private float multiplicadorGravedad;
    private float escalaGravedad;
    private bool botonSaltoArriba = true;

    private Jugador jugador;

    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    private bool saltando = false;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private AudioSource miAudioSource;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void Start()
    {
        escalaGravedad = miRigidbody2D.gravityScale;
    }
    private void Awake()
    {
        jugador = GetComponent<Jugador>();
        
    }

    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAudioSource = GetComponent<AudioSource>();
        jugador = GetComponent<Jugador>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        puedoSaltar = IsGrounded();

        if (Input.GetButton("Jump") && puedoSaltar)
        {
            saltando = true;

            if (miAudioSource.isPlaying) { return; }
            miAudioSource.PlayOneShot(jugador.PerfilJugador.JumpSFX);
        }

        if (Input.GetButtonUp("Jump"))
        {
            BotonSaltarArriba();
        }
    }

    private void FixedUpdate()
    {
        if (saltando && botonSaltoArriba)
        {
            miRigidbody2D.AddForce(Vector2.up * jugador.PerfilJugador.FuerzaSalto, ForceMode2D.Impulse);
            saltando = false;
            botonSaltoArriba = false;
        }

        if (miRigidbody2D.linearVelocityY < 0 && !puedoSaltar)
        {
            miRigidbody2D.gravityScale = escalaGravedad * multiplicadorGravedad;
        }
        else
        {
            miRigidbody2D.gravityScale = escalaGravedad;
        }

    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (miAudioSource.isPlaying) { return; }
        miAudioSource.PlayOneShot(jugador.PerfilJugador.CollisionSFX);
    }
    
    private void BotonSaltarArriba()
    {
        if (miRigidbody2D.linearVelocityY > 0)
        {
            miRigidbody2D.AddForce(Vector2.down * miRigidbody2D.linearVelocityY * (1 - multiplicadorCancelarSalto), ForceMode2D.Impulse);
        }
        botonSaltoArriba = true;
        saltando = false;

    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}