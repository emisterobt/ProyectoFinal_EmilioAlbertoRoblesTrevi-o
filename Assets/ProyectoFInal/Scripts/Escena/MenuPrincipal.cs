using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Juego()
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
