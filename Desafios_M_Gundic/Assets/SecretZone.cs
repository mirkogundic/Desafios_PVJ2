using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretZone : MonoBehaviour
{
    private TilemapRenderer m_Renderer;

    private void Awake()
    {
        m_Renderer = GetComponent<TilemapRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_Renderer.enabled = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_Renderer.enabled = true;
    }


}
