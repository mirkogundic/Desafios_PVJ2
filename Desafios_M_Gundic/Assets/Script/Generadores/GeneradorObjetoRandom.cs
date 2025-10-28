using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetoRandom : MonoBehaviour
{
    [SerializeField] private GameObject[] objetosPrefab;
    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;


    void Start()
    {

    }

    void GenerarObjetoRandom()
    {
        int indexAleatorio = Random.Range(0, objetosPrefab.Length);
        GameObject prefabAleatorio = objetosPrefab[indexAleatorio];
        Instantiate(prefabAleatorio, transform.position, Quaternion.identity);
    }

    private void OnBecameInvisible()
    {
        CancelInvoke(nameof(GenerarObjetoRandom));
    }

    private void OnBecameVisible()
    {
        InvokeRepeating(nameof(GenerarObjetoRandom), tiempoEspera, tiempoIntervalo);
    }

}
