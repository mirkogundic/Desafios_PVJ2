using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class DañoAJefe : MonoBehaviour
{
    [SerializeField] private float daño = 10;
    [SerializeField] private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject jefeEnemy = GameObject.FindWithTag("Jefe");

            if (jefeEnemy != null)
            {
                jefeEnemy.GetComponent<JefeArrow>().TomarDaño(daño);
                animator.SetTrigger("Entro");

            }

        }

    }

    void Destruirse()
    {
        gameObject.SetActive(false);
    }


}
