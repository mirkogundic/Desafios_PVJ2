using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;
    private Jugador jugador;
    public int velocidadX;

    [Header("Configuraciones de animación")]
    [SerializeField] private float animSpeedMin = 0.5f; // V.minima del Animator
    [SerializeField] private float animSpeedMax = 2f;   // V.maxima del Animator

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        jugador = GetComponent<Jugador>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxisRaw("Horizontal");
        //direccion = new Vector2(moverHorizontal, 0f);
        float velocidadActual = Mathf.Abs(miRigidbody2D.linearVelocityX);
        float velocidadAnim = Mathf.Clamp(1f + velocidadActual * jugador.PerfilJugador.MultiplicadorAnimacion, animSpeedMin, animSpeedMax);
        miAnimator.speed = velocidadAnim;


        velocidadX = (int)miRigidbody2D.linearVelocityX;
        //miSprite.flipX = velocidadX < 0;
        miAnimator.SetInteger("Velocidad", velocidadX);
    }
    private void FixedUpdate()
    {
        miRigidbody2D.linearVelocity = new Vector2(moverHorizontal * jugador.PerfilJugador.VelocidadHorizontal,miRigidbody2D.linearVelocityY);
        if ((moverHorizontal > 0 && !MirandoALaDerecha()) || (moverHorizontal < 0 && MirandoALaDerecha()))
        {
            Girar();
        }
    }

    private void Girar()
    {
        Vector2 escala =transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private bool MirandoALaDerecha()
    {
        return transform.localScale.x > 0;
    }
}
