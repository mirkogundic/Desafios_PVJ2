using UnityEngine;

public class ActivarObjetos : MonoBehaviour
{
    [Header("Objetos a Activar/Desactivar")]
    [SerializeField] public GameObject[] acciones;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (animator != null)
            {
                foreach (GameObject obj in acciones)
                {
                    if (obj != null)
                    {
                        bool cambiarEstado = !obj.activeSelf;
                        obj.SetActive(cambiarEstado);
                    }
                }
                animator.SetTrigger("Entro");
            }

            Destruirse();
        }
    }


    public void Destruirse()
    {
        Destroy(gameObject);
    }

}
