using System.Collections;
using UnityEngine;

public class ObstaculeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacule;
    [SerializeField] private int frequence;
    private int obstaculeRandom;
    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(Frequence());
    }

    private IEnumerator Frequence()
    {
        yield return new WaitForSeconds(frequence);
        RandomObstacule();
        Instantiate(obstacule[obstaculeRandom], transform.position, transform.rotation);
        StartCoroutine(Frequence());

    }

    private void RandomObstacule()
    {
        obstaculeRandom = Random.Range(0, 2);
    }
}
