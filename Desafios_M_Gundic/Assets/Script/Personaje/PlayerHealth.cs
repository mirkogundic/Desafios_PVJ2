using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int lives = 5;

    public UnityEvent<int> OnLivesChanged;

    public void LoseLife()
    {
        lives--;
        OnLivesChanged.Invoke(lives);

        if (lives <= 0)
        {
            //Usar en caso de Game over
        }
    }
}