using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private float movX;
    private float movY;

    [SerializeField]
    private Transform camara;

    private float velocidadActual;
    private float velocidadMax = 8;
    private float VelocidanNorm = 5;

    private CharacterController controlador;
    private float suavizado = 0.1f;
    private float velocidadSuavizado;

    private float salto = 3.5f;

    private Vector3 velocidadY;

    private float gravedad = -50f;

    private bool isGrounded;

    public Transform groundCheck;

    private float radio = 0.1f;

    [SerializeField]
    private LayerMask suelo;

    public Animator anim;
    private bool disparando;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controlador = GetComponent<CharacterController>();
        velocidadActual = VelocidanNorm;
        AudioManager.instance.Play("Happy");
    }
    private void Update()
    {

        Salto();
        Movimiento();
        Correr();
        
    }

    private void Salto()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, radio, suelo);

        velocidadY.y += gravedad * Time.deltaTime;
        if (isGrounded && velocidadY.y <= 0)
        {
            velocidadY.y = 0;
        }
        
        //Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !disparando)
        {
            AudioManager.instance.Play("Jump");
            velocidadY.y = Mathf.Sqrt(salto * gravedad * -2);
        }
    }

    private void Movimiento()
    {
        controlador.Move(velocidadY * Time.deltaTime);

        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movX, 0, movY).normalized;

        if (movimiento.magnitude > 0.1 && !disparando)
        {
            anim.SetBool("isMoving", true);
            float targetAngle = Mathf.Atan2(movimiento.x, movimiento.z) * Mathf.Rad2Deg + camara.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref velocidadSuavizado, suavizado);

            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 dirMov = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            controlador.Move(dirMov.normalized * velocidadActual * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void Correr()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocidadActual = velocidadMax;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidadActual = VelocidanNorm;
        }
    }

}
