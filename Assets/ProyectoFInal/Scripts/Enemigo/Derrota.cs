using UnityEngine;
using UnityEngine.SceneManagement;

public class Derrota : MonoBehaviour
{
    private void OnTriggerEnter(Collider colision)
    {
        if (colision.CompareTag("Player"))
        {
            GameManager.instance.enemigosVivos = 20;
            SceneManager.LoadScene("TerceraPersona");
        }
    }
}
