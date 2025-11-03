using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame instance;
    public int enemigosAsesinados;

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
    private void Start()
    {
        enemigosAsesinados = 0;
    }
    public void Finalizar()
    {
        if (enemigosAsesinados >= 30)
        {
            Application.Quit();

        }
    }

}
