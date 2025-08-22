using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string nivel;
    public string nombreGuardado;
    public int enemigosVivos;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void GuardarDatos()
    {
        nivel = SceneManager.GetActiveScene().name;
    }

}
