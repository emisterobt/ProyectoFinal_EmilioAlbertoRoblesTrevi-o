using UnityEngine;

public class Vidaenemigo : MonoBehaviour
{
    
    public int vida;
    public void Da�oEnemigo(int da�o)
    {
        
        vida -= da�o;
        if (vida <= 0)
        {
            GameManager.instance.enemigosVivos -= 1;
            AudioManager.instance.Play("Death");
            Destroy(this.gameObject);
        }
    }
}
