using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform jugador;
    private bool detect;
    private float radio = 6;
    [SerializeField]
    private LayerMask mask;


    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        detect = Physics.CheckSphere(transform.position, radio, mask);

        if (detect)
        {
            agent.SetDestination(jugador.position);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
