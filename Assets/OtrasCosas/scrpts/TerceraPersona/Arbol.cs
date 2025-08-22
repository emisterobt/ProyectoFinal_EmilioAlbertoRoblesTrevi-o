using UnityEngine;

public class Arbol : MonoBehaviour
{
    [SerializeField]private int vida;
    [SerializeField] private GameObject obj;
    [SerializeField] private int[] dropLimit;
    [SerializeField] private Transform spawn;

    public void Daño(int daño)
    {
        int rand = Random.Range(1, 6);

        for (int i = 0; i < rand; i++)
        {
            GameObject clone = Instantiate(obj, spawn.position, Quaternion.identity);
            int rx = Random.Range(1, 361);
            int ry = Random.Range(1, 361);
            int rz = Random.Range(1, 361);
            clone.transform.rotation = Quaternion.Euler(rx, ry, rz);
            int dx = Random.Range(1, 11);
            int dy = Random.Range(1, 11);
            int dz = Random.Range(1, 11);
            clone.GetComponent<Rigidbody>().AddForce(new Vector3(dx,dy,dz) * 10);

        }
        
        vida -= daño;

        if (vida <= 0)
        {
            Instantiate(obj, spawn.position, Quaternion.identity);
            Instantiate(obj, spawn.position, Quaternion.identity);
            Instantiate(obj, spawn.position, Quaternion.identity);
            Instantiate(obj, spawn.position, Quaternion.identity);
            Destroy(this.gameObject);   
        }
    }
}
