using UnityEngine;
using System.Collections;

public class SpawnDeArea : MonoBehaviour
{
    [Header("Configuraciones")]
    [SerializeField] private ObjectPool pool;                  
    [SerializeField] private Vector2 tamañoArea = new Vector2(10f, 5f);
    [SerializeField] private float intervalo = 2f;                     
    [SerializeField] private float duracionObjeto = 3f;

    private void Awake()
    {
        pool = GetComponent<ObjectPool>();
    }
    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalo);
            GameObject obj = pool.GetPooledObject();

            if (obj != null)
            {
                Vector2 posicionAleatoria = new Vector2(
                    transform.position.x + Random.Range(-tamañoArea.x / 2f, tamañoArea.x / 2f),
                    transform.position.y + Random.Range(-tamañoArea.y / 2f, tamañoArea.y / 2f)
                );

                obj.transform.position = posicionAleatoria;
                obj.transform.rotation = Quaternion.identity;
                obj.SetActive(true);

                StartCoroutine(Duracion(obj, duracionObjeto));
            }
        }
    }

    private IEnumerator Duracion(GameObject obj, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        if (obj != null && obj.activeSelf)
            obj.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, tamañoArea);
    }
}
