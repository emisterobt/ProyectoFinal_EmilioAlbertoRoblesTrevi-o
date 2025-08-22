using UnityEngine;

public class Bala : MonoBehaviour
{
    private bool check;
    private GameObject colObj;

    private void Update()
    {
        if (check)
        {
            colObj.gameObject.GetComponent<Vidaenemigo>().DañoEnemigo(1);
            check = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            AudioManager.instance.Play("Ouch");
            colObj = collision.gameObject;
            check = true;
            
        }
    }
}
