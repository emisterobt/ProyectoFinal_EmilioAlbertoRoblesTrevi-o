using UnityEngine;

public class Guardar : MonoBehaviour
{

    public bool puedeGuardar = false;
    public GameObject mensaje;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && puedeGuardar)
        {
            GameManager.instance.GuardarDatos();
            SistemaGuardado.GuardarPartida();
            Debug.Log("Guardar");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensaje.SetActive(true);
            puedeGuardar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensaje.SetActive(false);
            puedeGuardar = false;
        }
    }
}
