using UnityEngine;

public class IARobots : MonoBehaviour
{
    public Transform detectarDisparo;
    public Transform bulletExit;
    public GameObject balaEnemigo;
    public float distanciaMira;
    public LayerMask capaJugador;
    public bool jugadorDetect;
    public float intervaloBullet;
    public float ultimaBullet;
    public Animator animator;

    void Update()
    {
        jugadorDetect = Physics2D.Raycast(transform.position, transform.right, distanciaMira, capaJugador);

        if (jugadorDetect)
        {
            if (Time.time > intervaloBullet + ultimaBullet)
            {
                ultimaBullet = Time.time;
                animator.SetTrigger("Disparo");
                Invoke(nameof(Disparar), intervaloBullet);
            }
        }
    }

    private void Disparar()
    {
        Instantiate(balaEnemigo, bulletExit.position, bulletExit.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(bulletExit.position, bulletExit.position + transform.right * distanciaMira);
    }
}
