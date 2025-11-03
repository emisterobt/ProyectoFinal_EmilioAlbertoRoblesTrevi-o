using UnityEngine;
using System.Collections.Generic;

public class Reykast : MonoBehaviour
{

    [SerializeField]
    private int dañoAtaque;


    [SerializeField]
    private GameObject bala;
    [SerializeField]
    private Transform shooter;
    [SerializeField]
    private float fuerzaDisparo;

    private Transform shootPoint;
    [SerializeField]
    private LayerMask enemyMask;
    //void Start()
    //{
    //    shootPoint = transform.parent;
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform clone = Instantiate(bala, shooter.position, shooter.rotation).transform;
            clone .GetComponent<Rigidbody>().AddForce(transform.forward * (fuerzaDisparo*10));
            Destroy(clone.gameObject, 3);
        }
    }
}
