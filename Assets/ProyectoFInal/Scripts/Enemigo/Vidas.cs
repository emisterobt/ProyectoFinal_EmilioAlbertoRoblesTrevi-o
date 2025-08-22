using UnityEngine;
using UnityEngine.SceneManagement;

public class Vidas : MonoBehaviour
{
    private int vida = 3;
    public void Da�oEnemigo(int da�o)
    {
        vida -= da�o;
        if (vida <= 0)
        {
            GameManager.instance.enemigosVivos -= 1;
            AudioManager.instance.Play("Death");
            ComprobarEnemigosVivos();
            Destroy(this.gameObject);
        }
    }

    private void ComprobarEnemigosVivos()
    {
        if (GameManager.instance.enemigosVivos == 0)
        {
            SceneManager.LoadScene("Creditos");
        }
    }
}
