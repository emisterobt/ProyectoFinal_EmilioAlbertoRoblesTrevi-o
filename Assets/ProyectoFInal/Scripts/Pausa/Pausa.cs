using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject ui;
    private bool estaPausado = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !estaPausado)
        {
            estaPausado = true;
            Cursor.lockState = CursorLockMode.None;
            ui.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && estaPausado)
        {
            estaPausado = false;
            Cursor.lockState = CursorLockMode.None;
            ui.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu Principal");
    }
}
