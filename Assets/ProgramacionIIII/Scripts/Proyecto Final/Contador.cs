using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText; // Arrastrar el Text del UI (opcional)

    private float tiempoTranscurrido = 0f;
    private bool corriendo = true;

    private void Start()
    {
        tiempoTranscurrido = 0f;
    }
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        int minutos = (int)(tiempoTranscurrido / 60);
        int segundos = (int)(tiempoTranscurrido % 60);
        int milisegundos = (int)((tiempoTranscurrido * 1000) % 1000);

        string tiempoFormateado = string.Format("{0:00}:{1:00}:{2:000}", minutos, segundos, milisegundos);

        Debug.Log(tiempoFormateado);

        timerText.text = tiempoFormateado;
    }
}
