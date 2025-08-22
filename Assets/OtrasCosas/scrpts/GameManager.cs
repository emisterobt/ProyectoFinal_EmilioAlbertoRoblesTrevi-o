using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int dinero;
    public int enemigos = 20;

    public int colect;

    public float posX;
    public float posY;
    public float posZ;

    public string nivel;

    private Transform player;

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
        player = GameObject.FindGameObjectWithTag("Player").transform;
        posX = player.position.x;
        posY = player.position.y;
        posZ = player.position.z;
        nivel = SceneManager.GetActiveScene().name;
    }

}
