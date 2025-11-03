using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoint; //Puntos donde puede spawnear los objetos
    [SerializeField] private GameObject objectToSpawn; //El objeto a spawnear
    [SerializeField] private float spawnRate;

    [SerializeField] private int poolSize; //Cantidad de objetos a disponer
    [SerializeField] private int maxObjectsInScene; //Cantidad maxima de objetos que pueden estar activos
    [SerializeField] private int activeObjects; //Objetos activos

    Queue<GameObject> pool; //Almacena objetos a disponer

    private void Start()
    {
        pool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++) 
        {
            GameObject instance = Instantiate(objectToSpawn);
            instance.SetActive(false);
            pool.Enqueue(instance);//En espera
        }

        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        for (int i = activeObjects; activeObjects < maxObjectsInScene; i++)
        { 
            yield return new WaitForSeconds(spawnRate);
            GameObject objeto = pool.Dequeue();
            objeto.transform.position = GetRandomSpawn().position;
            objeto.SetActive(true);
            activeObjects++;
            StartCoroutine(BackToQueue(objeto));
        }
    }

    private IEnumerator BackToQueue(GameObject objeto)
    {
        yield return new WaitForSeconds(5f);
        objeto.SetActive(false);
        pool.Enqueue(objeto);
        activeObjects--;
    }

    private Transform GetRandomSpawn()
    {
        int randomSpawn = Random.Range(0, spawnPoint.Length);

        return spawnPoint[randomSpawn];
        
    }


}
