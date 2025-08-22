using UnityEngine;

public class CambioNivel : MonoBehaviour
{
    [SerializeField] private string nivel;
    [SerializeField] private bool areaEspecifica;
    [SerializeField] private string nombreArea;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ManejoEscena.instance.CambioEscena(nivel, areaEspecifica, nombreArea);
        }
    }
}
