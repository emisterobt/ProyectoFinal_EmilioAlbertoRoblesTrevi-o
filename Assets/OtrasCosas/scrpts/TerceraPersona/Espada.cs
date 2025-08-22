using UnityEngine;

public class Espada : MonoBehaviour
{

    [SerializeField] private int da�o;
    private void OnTriggerEnter(Collider colision)
    {
        if (colision.GetComponent<Arbol>() != null)
        {
            colision.GetComponent<Arbol>().Da�o(da�o);
        }
        
    }
}
