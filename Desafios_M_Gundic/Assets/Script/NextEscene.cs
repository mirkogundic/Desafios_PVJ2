using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class NextEscene : MonoBehaviour
{
    [SerializeField] private UnityEvent EscenaSiguiente;
    private int indiceEscenaActual;

    public void Start()
    {
        indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EscenaSiguiente.Invoke();
        }
    }

    public void ResetEscena()
    {
        SceneManager.LoadScene(indiceEscenaActual);
    }
}

