using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    public Contador contador;

    public void CanvasActivation()
    {
        Manager.instance.score = contador.segundos;
        Manager.instance.UpdateScore();
        canvas.SetActive(true);
    }

    public void MenuBack()
    {
        SceneManager.LoadScene("CreareAccount");
    }

    public void Game()
    {
        SceneManager.LoadScene("FigureJump");
    }

    public void PrincipalMenu()
    {
        SceneManager.LoadScene("PrincipalMenu");
    }
}
