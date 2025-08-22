using UnityEngine;

public class Guardar : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
        {
            GameManager.instance.GuardarDatos();
            SistemaGuardado.GuardarPartida();
            Debug.Log("Guardar");
        }

    }
}
