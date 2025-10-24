using UnityEngine;

public class AlertaDeInteraccion : MonoBehaviour
{
    private GameObject alertSignal;

    void Update()
    {
        alertSignal = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            alertSignal.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            alertSignal.SetActive(false);
        }
    }
}
