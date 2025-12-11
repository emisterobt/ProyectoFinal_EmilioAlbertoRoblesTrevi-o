using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private float tiempoTranscurrido = 0f;
    public int segundos = 0;

    private void Start()
    {
        tiempoTranscurrido = 0f;
        segundos = 0;
    }

    void Update()
    {
        // Aumentar tiempo en float
        tiempoTranscurrido += Time.deltaTime;

        // Convertir a segundos enteros
        segundos = Mathf.FloorToInt(tiempoTranscurrido);

        // Mostrar solo los segundos
        timerText.text = segundos.ToString();
    }
}
