using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{
    public bool puedeReiniciar = false;
    public GameObject mensaje;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && puedeReiniciar)
        {
            GameManager.instance.enemigosVivos = 20;
            SceneManager.LoadScene("TerceraPersona");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensaje.SetActive(true);
            puedeReiniciar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensaje.SetActive(false);
            puedeReiniciar = false;
        }
    }
}
