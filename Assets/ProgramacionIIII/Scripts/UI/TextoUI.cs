using TMPro;
using UnityEngine;

public class TextoUI : MonoBehaviour
{
    public TextMeshProUGUI miTexto;
    [SerializeField] private ManagerGame manager;

    void Start()
    {
        string textoActual = miTexto.text;
    }

    private void Update()
    {
        miTexto.text = "Freddys Asesinados: " + manager.enemigosAsesinados + "/30";
    }
}
