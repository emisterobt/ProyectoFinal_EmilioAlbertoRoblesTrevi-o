using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    public void CanvasActivation()
    {

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
}
