using UnityEngine;

public class Bala : MonoBehaviour
{
    private bool haceDaño;
    private GameObject enemigo;

    private void Update()
    {
        if (haceDaño)
        {
            enemigo.gameObject.GetComponent<Vidas>().DañoEnemigo(1);
            haceDaño = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            AudioManager.instance.Play("Ouch");
            enemigo = collision.gameObject;
            haceDaño = true;
            
        }
    }
}
