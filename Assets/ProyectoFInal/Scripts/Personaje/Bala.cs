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
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemigo = collision.gameObject;
            haceDaño = true;
            
        }
    }
}
