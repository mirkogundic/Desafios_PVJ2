using UnityEngine;

public class MirarAJugador : MonoBehaviour
{
    public GameObject Jugador;

    private void Start()
    {
        Jugador = GameObject.Find("Jugador");
    }
    void Update()
    {
        if (Jugador.transform.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
