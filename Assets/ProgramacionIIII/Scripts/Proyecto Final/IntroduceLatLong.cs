using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class IntroduceLatLong : MonoBehaviour
{
   

    public TMP_InputField inputLat;
    public TMP_InputField inputLon;


    public void Game()
    {

        SceneManager.LoadScene("FigureJump");
    }

    

    public void ObtenerValor()
    {
        Manager.instance.latManager = float.Parse(inputLat.text);
        Manager.instance.lonManager = float.Parse(inputLon.text);

        Debug.Log(Manager.instance.lonManager + " " + Manager.instance.latManager);
        Game();
    }

    public void Salir()
    {
        Application.Quit();

    }
}
