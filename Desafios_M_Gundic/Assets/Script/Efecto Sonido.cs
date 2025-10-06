using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EfectodeSonido : MonoBehaviour
{
    [SerializeField] private AudioClip Agarrar;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(Agarrar);
        }
    }
}