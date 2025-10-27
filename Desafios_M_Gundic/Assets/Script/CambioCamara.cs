using Unity.Cinemachine;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    [SerializeField] GameObject camara2;

    private void Awake()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camara2.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camara2.gameObject.SetActive(true);
        }
    }
}
