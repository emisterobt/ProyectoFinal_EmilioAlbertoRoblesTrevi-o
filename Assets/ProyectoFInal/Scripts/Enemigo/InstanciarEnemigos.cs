using UnityEngine;

public class InstanciarEnemigos : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private int cantidad;
    private Vector3 centro = Vector3.zero;
    private Vector3 tama�o = new Vector3(50f, 0f, 50f);

    void Start()
    {
        cantidad = GameManager.instance.enemigosVivos;
        InstanciarPrefabs();
    }

    void InstanciarPrefabs()
    {
        for (int i = 0; i < cantidad; i++)
        {
            Vector3 posicionAleatoria = PosicionAleatoria();
            Instantiate(prefab, posicionAleatoria, Quaternion.identity);
        }
    }

    Vector3 PosicionAleatoria()
    {
        Vector3 pos = new Vector3(
            Random.Range(centro.x - tama�o.x / 2, centro.x + tama�o.x / 2),
            Random.Range(centro.y - tama�o.y / 2, centro.y + tama�o.y / 2),
            Random.Range(centro.z - tama�o.z / 2, centro.z + tama�o.z / 2)
        );

        return pos;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(centro, tama�o);
    }
}
