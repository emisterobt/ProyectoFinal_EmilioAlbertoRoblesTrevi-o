using TMPro;
using UnityEngine;

public class TextoUI : MonoBehaviour
{
    public TextMeshProUGUI miTexto;

    void Start()
    {
        string textoActual = miTexto.text;
    }

    private void Update()
    {
        miTexto.text = "Enemigos Vivos: " + GameManager.instance.enemigosVivos;
    }
}
