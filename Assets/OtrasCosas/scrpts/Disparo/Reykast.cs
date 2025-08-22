using UnityEngine;
using System.Collections.Generic;

public class Reykast : MonoBehaviour
{

    [SerializeField]
    private int dañoAtaque;
    [SerializeField]
    private int force;

    [SerializeField]
    private GameObject bala;
    [SerializeField]
    private Transform shooter;
    [SerializeField]
    private float fuerzaDisparo;

    private Transform shootPoint;
    private RaycastHit hit;
    [SerializeField]
    private LayerMask enemyMask;

    private GameObject objeto;
    public List <GameObject> chofer = new();

    [SerializeField]
    private int cantidad;
    void Start()
    {
        shootPoint = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, 100);

            if (hit.transform != null)
            {
                Debug.Log(hit.transform.name);

                if (hit.transform.CompareTag("Enemy"))
                {
                    hit.rigidbody.AddForce(-hit.normal * force);
                    hit.transform.GetComponent<Vidas>().DañoEnemigo(dañoAtaque);
                }

                if (hit.transform.CompareTag("Objeto"))
                {
                    objeto = hit.transform.gameObject;
                    Destroy(objeto);
                    for (int i = 0; i < (cantidad+3); i++)
                    {
                        Instantiate(objeto, objeto.transform.position, objeto.transform.rotation);
                        i++;
                    }
                    
                }

                if (hit.transform.CompareTag("Chofer"))
                {
                    chofer.Add(hit.transform.gameObject);
                    chofer[^1].SetActive(false);

                }
            }


        }

        if (Input.GetMouseButtonDown(1))
        {
            if (chofer.Count > 0)
            {
                Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, 100);
                if (hit.transform != null)
                {
                    GameObject clone = Instantiate(chofer[^1], hit.point, chofer[^1].transform.rotation);
                    clone.SetActive(true);
                    Destroy(chofer[^1]);
                    chofer.Remove(chofer[^1]);
                    
                }
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AudioManager.instance.Play("Shoot");
            Transform clone = Instantiate(bala, shooter.position, shooter.rotation).transform;
            clone .GetComponent<Rigidbody>().AddForce(transform.forward * (fuerzaDisparo*10));
            Destroy(clone.gameObject, 10);
        }
    }
}
