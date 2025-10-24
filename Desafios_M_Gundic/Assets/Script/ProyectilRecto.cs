using UnityEngine;

public class ProyectilRecto : MonoBehaviour
{
    [Header("Configuración de velocidad y vida")]
    [SerializeField, Range(1f, 30f)] private float speed = 10f;
    [SerializeField, Range(0.5f, 10f)] private float tiempoDeVida = 3f;

    public Vector2 direccion = Vector2.zero;

    private Rigidbody2D rb2d;
    private Coroutine desactivador;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Mover();

        desactivador = StartCoroutine(DesactivarDespuesDeTiempo());
    }

    private void OnDisable()
    {
        if (desactivador != null)
            StopCoroutine(desactivador);
    }

    public void SetDireccion(Vector2 nuevaDireccion)
    {
        direccion = nuevaDireccion.normalized;
        rb2d.linearVelocity = direccion * speed;
    }

    private void Mover()
    {
        rb2d.linearVelocity = direccion.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Muros"))
        {
            gameObject.SetActive(false);
        }
    }

    private System.Collections.IEnumerator DesactivarDespuesDeTiempo()
    {
        yield return new WaitForSeconds(tiempoDeVida);
        gameObject.SetActive(false);
    }
}
