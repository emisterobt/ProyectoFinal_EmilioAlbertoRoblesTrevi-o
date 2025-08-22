using UnityEngine;
using UnityEngine.AI;

public class EnemigoV2 : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform jugador;

    private bool detect;
    [SerializeField]
    private float radio;
    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private Vector3 iniPos;


    public int coordenada;
    private void Start()
    {
        iniPos = transform.position;
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
