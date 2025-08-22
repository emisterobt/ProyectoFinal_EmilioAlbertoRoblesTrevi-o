using UnityEngine;
using UnityEngine.SceneManagement;

public class Vidas : MonoBehaviour
{
    private int vida = 3;
    public void DañoEnemigo(int daño)
    {
        vida -= daño;
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
