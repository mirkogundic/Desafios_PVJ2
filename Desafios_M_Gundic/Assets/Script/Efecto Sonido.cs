using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EfectodeSonido : MonoBehaviour
{
    [SerializeField] private AudioClip Agarrar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ControladorSonido.Instance.EjecutarSonido(Agarrar);
            Destroy(gameObject);
        }
    }
}