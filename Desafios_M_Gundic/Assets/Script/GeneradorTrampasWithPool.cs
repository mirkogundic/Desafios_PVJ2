using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GeneradorTrampasWithPool : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;

    [SerializeField] private Vector2 direccionProyectil = Vector2.zero;

    private ObjectPool objectPool;
    private AudioSource miaudioSource;
    public AudioClip generateSFX;

    private void Awake()
    {
        miaudioSource = GetComponent<AudioSource>();
        objectPool = GetComponent<ObjectPool>();
    }
    void Start()
    {
        InvokeRepeating(nameof(GenerarObjetoLoop), tiempoEspera, tiempoIntervalo);
    }

    void GenerarObjetoLoop()
    {
        GameObject pooledObject = objectPool.GetPooledObject();
        if (pooledObject != null)
        {
            pooledObject.transform.position = transform.position;
            pooledObject.transform.rotation = Quaternion.identity;
            pooledObject.SetActive(true);
            miaudioSource.PlayOneShot(generateSFX);

            ProyectilRecto proyectil = pooledObject.GetComponent<ProyectilRecto>();
            if (proyectil != null)
            {
                proyectil.SetDireccion(direccionProyectil);
            }
        }

    }
}