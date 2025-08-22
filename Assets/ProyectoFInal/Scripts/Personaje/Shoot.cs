using System.Runtime.CompilerServices;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float force;
    void Start()
    {
        
    }

 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.instance.Play("Shoot");
            Transform clone = Instantiate(bullet, transform.position, transform.rotation).transform;
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * (force * 10));
            Destroy(clone.gameObject, 10);
        }
    }
}
