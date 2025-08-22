using UnityEngine;
using UnityEngine.AI;

public class EnemigoAntiguo : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform prota;

    private bool detect;
    [SerializeField]
    private float radio;
    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private Vector3 iniPos;

    [SerializeField]
    private Transform[] puntosDePatrulla;

    public int coordenada;
    private void Start()
    {
        iniPos = transform.position;
        prota = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        detect = Physics.CheckSphere(transform.position, radio, mask);

        if (Vector3.Distance(transform.position, puntosDePatrulla[coordenada].position) < 1)
        {
            coordenada++;
            if (coordenada >= puntosDePatrulla.Length)
            {
                coordenada = 0;
            }
        }


        if (detect)
        { 
            agent.SetDestination(prota.position); 
        }
        if (!detect)
        {
            agent.SetDestination(puntosDePatrulla[coordenada].position);
            agent.stoppingDistance = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    
}
