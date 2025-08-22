using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejoEscena : MonoBehaviour
{

    public static ManejoEscena instance;

    private string nivelVoy;
    private string areaVoy;
    private bool areaEspecifico;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    public void CambioEscena(string nivel, bool especifico, string area)
    {

        
            nivelVoy = nivel;
            areaVoy = area;
        areaEspecifico = especifico;
            StartCoroutine(Waiter());
      
        
    }

    IEnumerator Waiter() 
    {
        transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(nivelVoy);
        yield return new WaitForSeconds(0.5f);
        if (areaEspecifico)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;

            player.GetComponent<CharacterController>().enabled = false;
            Transform spawnPoint = GameObject.Find(areaVoy).transform;
            player.position = spawnPoint.position;
            player.rotation = spawnPoint.rotation;

            player.GetComponent<CharacterController>().enabled = true;
        }
        
        transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
    }

    

}
