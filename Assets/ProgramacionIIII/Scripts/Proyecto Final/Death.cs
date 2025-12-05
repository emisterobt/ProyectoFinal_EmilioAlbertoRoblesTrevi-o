using UnityEngine;

public class Death : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanvasController controller =  GameObject.Find("CanvasController").GetComponent<CanvasController>();
            controller.CanvasActivation();

            Debug.Log("Estas muerto");
            Time.timeScale = 0f;
            
        }
    }
}
