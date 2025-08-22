using UnityEngine;

public class Moneda : MonoBehaviour
{
    public bool cursorIn;
    public bool inside;
    [SerializeField]
    private float radio;
    [SerializeField]
    private LayerMask mask;
    private void OnMouseEnter()
    {
        cursorIn = true;
    }
    private void OnMouseExit() 
    {
        cursorIn = false;
    }

    private void Update()
    {

        inside = Physics.CheckSphere(transform.position, radio, mask);
        if (Input.GetKeyDown(KeyCode.E) && cursorIn && inside)
        {
            Destroy(this.gameObject);
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;   
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
