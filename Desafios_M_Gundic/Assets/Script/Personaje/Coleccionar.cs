using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionar : MonoBehaviour
{
    [SerializeField] private List<GameObject> collecionables;
    [SerializeField] private GameObject Bolsa;

    private bool presionado = false;

    private void Awake()
    {
        collecionables = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Coleccionables")) { return; }

        GameObject nuevoColeccionable = collision.gameObject;
        nuevoColeccionable.SetActive(false);

        collecionables.Add(nuevoColeccionable);
        nuevoColeccionable.transform.SetParent(Bolsa.transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (collecionables.Count == 0) return;

            presionado = !presionado;
            collecionables[0].SetActive(presionado);
        }

    }
}
