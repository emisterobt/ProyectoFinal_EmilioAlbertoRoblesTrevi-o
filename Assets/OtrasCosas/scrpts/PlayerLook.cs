using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Transform padre;
    private float mox;
    private float moy;

    [SerializeField]
    private float MouseSenseX;

    [SerializeField]
    private float MouseSenseY;

    private float rotX = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//Desaparecer el cursor
        padre = transform.parent;
    }

    private void Update()
    {
        
        mox = Input.GetAxis("Mouse X") * MouseSenseX * Time.deltaTime;
        padre.Rotate(0, mox, 0);

        moy = Input.GetAxis("Mouse Y") * MouseSenseY * Time.deltaTime;
        rotX -= moy; //para invertir se pone +
        rotX = Mathf.Clamp(rotX, -90, 90);
        transform.localRotation = Quaternion.Euler(rotX, 0, 0);
    }
}
