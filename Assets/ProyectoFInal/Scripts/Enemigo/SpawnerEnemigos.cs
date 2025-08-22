using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    [Header("Prefab a Instanciar")]
    public GameObject prefab;

    [Header("Cantidad de Prefabs")]
    public int cantidad;

    [Header("�rea de Spawneo (Centro y Tama�o)")]
    public Vector3 centro = Vector3.zero;
    public Vector3 tama�o = new Vector3(10f, 0f, 10f);

    void Start()
    {
        cantidad = GameManager.instance.enemigosVivos;
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < cantidad; i++)
        {
            Vector3 posicionAleatoria = GenerarPosicionAleatoria();
            Instantiate(prefab, posicionAleatoria, Quaternion.identity);
        }
    }

    Vector3 GenerarPosicionAleatoria()
    {
        Vector3 pos = new Vector3(
            Random.Range(centro.x - tama�o.x / 2, centro.x + tama�o.x / 2),
            Random.Range(centro.y - tama�o.y / 2, centro.y + tama�o.y / 2),
            Random.Range(centro.z - tama�o.z / 2, centro.z + tama�o.z / 2)
        );

        return pos;
    }

    // Visualizaci�n en la escena del �rea de spawneo
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(centro, tama�o);
    }
}
