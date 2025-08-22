using UnityEngine;

public class Bala : MonoBehaviour
{
    private bool haceDa�o;
    private GameObject enemigo;

    private void Update()
    {
        if (haceDa�o)
        {
            enemigo.gameObject.GetComponent<Vidas>().Da�oEnemigo(1);
            haceDa�o = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            AudioManager.instance.Play("Ouch");
            enemigo = collision.gameObject;
            haceDa�o = true;
            
        }
    }
}
