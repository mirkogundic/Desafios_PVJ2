using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PuertasAcceso : MonoBehaviour
{
    [SerializeField] private UnityEvent EscenaSiguiente;
    private bool playerInArea;
    private void Update()
    {
        if (playerInArea && Input.GetKeyDown(KeyCode.E))
        {
            EscenaSiguiente.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInArea = true;
            Debug.Log("Jugador cerca de la puerta");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInArea = false;
            Debug.Log("Jugador se alejó de la puerta");
        }
    }
}
