using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    public TMP_Text livesText;

    public void ActualizarTextoHUB(string nuevotexto)
    {
        livesText.text = $"Vidas: {nuevotexto}";
    }
}