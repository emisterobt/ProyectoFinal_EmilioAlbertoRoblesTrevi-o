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
            //GameManager.instance.enemigosVivos -= 1;
            //ComprobarEnemigosVivos();
            ManagerGame.instance.enemigosAsesinados += 1;
            ManagerGame.instance.Finalizar();
            gameObject.SetActive(false);

        }
    }

    //private void ComprobarEnemigosVivos()
    //{
    //    if (GameManager.instance.enemigosVivos == 0)
    //    {
    //        SceneManager.LoadScene("Creditos");
    //    }
    //}
}
