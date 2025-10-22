using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAdeSeguimientoAereo: MonoBehaviour
{
    public float radioBusqueda;
    public LayerMask capaJugador;
    public Transform transformJugador;
    public float velocidadMovimiento;
    public float distanciaMaxima;
    public Vector3 puntoInicial;
    public bool mirandoDerecha;


    public EstadosMovimiento estadoActual;
    public enum EstadosMovimiento
    {
        Esperado,
        Siguiendo,
        Volviendo,
    }
    private void Start()
    {
        puntoInicial = transform.position;
        velocidadMovimiento = Random.Range(3, 5);
    }

    private void Update()
    {
        switch (estadoActual)
        {
            case EstadosMovimiento.Esperado:
                EstadoEsperando();
                break;
            case EstadosMovimiento.Siguiendo:
                EstadoSiguiendo();
                break;
            case EstadosMovimiento.Volviendo:
                EstadoVolviendo();
                break;
        }


    }

    private void EstadoEsperando()
    {
        Collider2D jugadorCollider = Physics2D.OverlapCircle(transform.position, radioBusqueda, capaJugador);

        if (jugadorCollider)
        {
            transformJugador = jugadorCollider.transform;

            estadoActual = EstadosMovimiento.Siguiendo;
        }
    }

    private void EstadoSiguiendo()
    {
        if (transformJugador == null)
        {
            estadoActual = EstadosMovimiento.Volviendo;
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, transformJugador.position, velocidadMovimiento * Time.deltaTime);

        GirarAObjeto(transformJugador.position);
    
        if (Vector2.Distance(transform.position, puntoInicial) > distanciaMaxima ||
            Vector2.Distance(transform.position, transformJugador.position) > distanciaMaxima) 
        {
            estadoActual = EstadosMovimiento.Volviendo;
        }
    }

    private void EstadoVolviendo()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntoInicial, velocidadMovimiento * Time.deltaTime);
        GirarAObjeto(puntoInicial);

        if (Vector2.Distance(transform.position, puntoInicial) < 0.01f)
        {
            estadoActual = EstadosMovimiento.Esperado;
        }

    }

    private void GirarAObjeto(Vector3 objetivo)
    {
        if (objetivo.x > transform.position.x && !mirandoDerecha)
        {
            Girar();
        }
        else if (objetivo.x <transform.position.x && mirandoDerecha)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180,0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioBusqueda);
        Gizmos.DrawWireSphere(puntoInicial, distanciaMaxima);

    }
}

