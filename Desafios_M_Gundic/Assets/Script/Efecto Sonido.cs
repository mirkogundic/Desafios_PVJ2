using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EfectodeSonido : MonoBehaviour
{
    [SerializeField] private AudioClip agarrar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ControladorSonido.Instance.EjecutarSonido(agarrar);
            Destroy(gameObject);
        }


    }


}
