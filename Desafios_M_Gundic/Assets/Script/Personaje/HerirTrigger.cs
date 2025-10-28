using UnityEngine;
using System.Collections;

public class HerirTrigger : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float constDaño = -1f;
    [SerializeField] private float intervaloDaño = 0.5f;
    private bool onPlayer = false;
    private Jugador jugador;
    private Coroutine inCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugador = collision.GetComponent<Jugador>();
            if (jugador != null && inCoroutine == null)
            {
                onPlayer = true;
                inCoroutine = StartCoroutine(BucleDeDaño());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onPlayer = false;

            if (inCoroutine != null)
            {
                StopCoroutine(inCoroutine);
                inCoroutine = null;
            }
        }
    }

    private IEnumerator BucleDeDaño()
    {
        while (onPlayer)
        {
            jugador.ModificarVida(constDaño);
            yield return new WaitForSeconds(intervaloDaño);
        }
    }
}
