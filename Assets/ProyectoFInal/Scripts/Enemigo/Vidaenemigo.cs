using UnityEngine;

public class Vidaenemigo : MonoBehaviour
{
    
    public int vida;
    public void DañoEnemigo(int daño)
    {
        
        vida -= daño;
        if (vida <= 0)
        {
            GameManager.instance.enemigosVivos -= 1;
            AudioManager.instance.Play("Death");
            Destroy(this.gameObject);
        }
    }
}
