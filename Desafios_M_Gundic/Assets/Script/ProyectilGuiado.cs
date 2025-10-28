using System;
using UnityEngine;

public class ProyectilGuiado : MonoBehaviour
{
    public Transform jugadorPosicion;
    public float Velocidad;
    public float anguloInicial;
    public float velocidadRotacion;
    public float daño;

    void Start()
    {
        GameObject jugadorObject = GameObject.FindGameObjectWithTag("Player");

        if (jugadorObject == null)
        {
            Destroy(gameObject);
        }
        else {
            jugadorPosicion = jugadorObject.transform;
        }

    }

    void Update()
    {
        transform.Translate(Velocidad * Time.deltaTime * Vector2.right, Space.Self);

        if (jugadorPosicion == null) {return; }

        //Esto fue sacadado de BravePixelG. Entendi la mitad y demasiado...

        float anguloRadianes = MathF.Atan2(jugadorPosicion.position.y - transform.position.y, jugadorPosicion.position.x - transform.position.x);
        float anguloGrados = 180 / MathF.PI * anguloRadianes - anguloInicial;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0, anguloGrados), Time.deltaTime * velocidadRotacion);
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Jugador jugadorScript))
        {
            jugadorScript.ModificarVida(-daño);
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Suelo"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Jefe"))
        {
            JefeArrow jefe = collision.GetComponent<JefeArrow>();

                if (jefe != null) {

                    jefe.TomarDaño(daño);
                }
            
            Destroy(gameObject);
        }

    }

}
