using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    [Header("Prefab a Instanciar")]
    public GameObject prefab;

    [Header("Cantidad de Prefabs")]
    public int cantidad;

    [Header("Área de Spawneo (Centro y Tamaño)")]
    public Vector3 centro = Vector3.zero;
    public Vector3 tamaño = new Vector3(10f, 0f, 10f);

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
            Random.Range(centro.x - tamaño.x / 2, centro.x + tamaño.x / 2),
            Random.Range(centro.y - tamaño.y / 2, centro.y + tamaño.y / 2),
            Random.Range(centro.z - tamaño.z / 2, centro.z + tamaño.z / 2)
        );

        return pos;
    }

    // Visualización en la escena del área de spawneo
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(centro, tamaño);
    }
}
