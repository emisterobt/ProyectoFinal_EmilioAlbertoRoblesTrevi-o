using UnityEngine;

public class Espada : MonoBehaviour
{

    [SerializeField] private int daño;
    private void OnTriggerEnter(Collider colision)
    {
        if (colision.GetComponent<Arbol>() != null)
        {
            colision.GetComponent<Arbol>().Daño(daño);
        }
        
    }
}
