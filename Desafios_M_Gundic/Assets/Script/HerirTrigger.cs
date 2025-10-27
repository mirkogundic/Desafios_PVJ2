using UnityEngine;
using System.Collections;

public class HerirTrigger : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float constDa�o = -1f;
    [SerializeField] private float intervaloDa�o = 0.5f;
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
                inCoroutine = StartCoroutine(BucleDeDa�o());
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

    private IEnumerator BucleDeDa�o()
    {
        while (onPlayer)
        {
            jugador.ModificarVida(constDa�o);
            yield return new WaitForSeconds(intervaloDa�o);
        }
    }
}
