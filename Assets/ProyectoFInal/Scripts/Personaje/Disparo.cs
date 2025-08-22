using System.Runtime.CompilerServices;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] private GameObject bala;
    [SerializeField] private float potencia;

    void Update()
    {
        Disparando();
    }

    private void Disparando()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.instance.Play("Shoot");
            Transform clone = Instantiate(bala, transform.position, transform.rotation).transform;
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * (potencia * 20));
            Destroy(clone.gameObject, 10);
        }
    }
}
