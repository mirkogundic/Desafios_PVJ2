using UnityEngine;

public class JefeArrow : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    private bool mirandoDerecha = true;
    private ObjectPool objetoPool;

    [Header("Vida")]
    [SerializeField] private float vida;
    [SerializeField] private BarraVida barraDeVida;

    [Header("Ataque Corto")]
    [SerializeField] private Transform controlarAtaque;
    [SerializeField] private Vector2 tamañoAtaque;
    [SerializeField] private float dañoAtaque;

    [Header("Ataque Arco Basico")]
    private float proximoDisparo;
    [SerializeField] private Transform controladorArco;
    [SerializeField] private float rangoDeteccion = 8f;
    [SerializeField] private float intervaloDisparos = 2f;

    [Header("Death Boss")]
    [SerializeField] public GameObject[] accionesDeath;



    void Start()
    {
        objetoPool = GetComponent<ObjectPool>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        barraDeVida.InicializarBarraVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {

        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);

        if (distanciaJugador >= rangoDeteccion && Time.time >= proximoDisparo)
        {
            proximoDisparo = Time.time + intervaloDisparos;
            animator.SetTrigger("FueraArea");
        }


    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if (vida <= 0)
        {
            animator.SetTrigger("ArrowDeath");
        }
    }

    private void Muerte()
    {
        foreach (GameObject obj in accionesDeath)
        { 
            if (obj != null)
            {
                bool cambiarEstado = !obj.activeSelf;
                obj.SetActive(cambiarEstado);
            }
        }

        Destroy(gameObject);
    }

    public void MirarJugador()
    {
        if ((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapBoxAll(controlarAtaque.position, tamañoAtaque,0f);

        foreach (Collider2D colision in objetos)
        {
            if (colision.CompareTag("Player"))
            {
                colision.GetComponent<Jugador>().ModificarVida(-dañoAtaque);
            }
        }
    }

    public void HabilidadFlechaRecta()
    {
        MirarJugador();

        GameObject obj = null;
        if (objetoPool != null)
        {
            obj = objetoPool.GetPooledObject();
            obj.transform.position = controladorArco.position;
            obj.transform.rotation = Quaternion.identity;
        }

        Vector2 direccion = mirandoDerecha ? Vector2.right : Vector2.left;

        obj.transform.right = direccion;

        ProyectilRecto proyectil = obj.GetComponent<ProyectilRecto>();
        if (proyectil != null)
        {
            proyectil.SetDireccion(direccion);
        }
        obj.SetActive(true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controlarAtaque.position, tamañoAtaque);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }


}
