using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;

    // Referencia al transform del jugador serializada
    [SerializeField] Transform jugador;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Vector2 direccion;
    private Vector2 movimiento;
    private SpriteRenderer miSprite;

    private void Awake()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miSprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //Se Modifico para que solo siga el Movimiento en X
        Vector2 direccion = (jugador.position - transform.position).normalized;
        movimiento = new Vector2(direccion.x, 0);
        miSprite.flipX = movimiento.x > 0;

        miRigidbody2D.MovePosition(miRigidbody2D.position + movimiento * velocidad * Time.deltaTime);
    }
}