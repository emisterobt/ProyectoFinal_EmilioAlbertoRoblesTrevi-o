using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{
    public void Jugaras()
    {
        SceneManager.LoadScene("TerceraPersona");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu Principal");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
