using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    private float movX;
    private float movY;

    [SerializeField]
    private Transform cam;

   
    private float velocidadActual;

    [SerializeField]
    private float velocidadMax;

    [SerializeField]
    private float VelocidanNorm;

    private CharacterController charCtrl;

    [SerializeField]
    private float smoothing = 0.1f;
    private float smoothingVelo;

    [SerializeField]
    [Range(0, 100)]
    private float jumpSpeed;

    private Vector3 velocitY;

    [SerializeField]
    private float gravedad = -9.8f;

    [SerializeField]
    private bool isGrounded;

    public Transform groundCkeck;

    [SerializeField]
    private float radio;

    [SerializeField]
    private LayerMask whatIsGround;

    //Animacion
    public Animator anim;

    private bool golpeando;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        charCtrl = GetComponent<CharacterController>();
        velocidadActual = VelocidanNorm;
        AudioManager.instance.Play("Happy");
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCkeck.position, radio, whatIsGround);

        anim.SetBool("isGrounded", isGrounded);

        velocitY.y += gravedad * Time.deltaTime;
        if (isGrounded && velocitY.y <= 0)
        {
            velocitY.y = 0;
        }
        
        //Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !golpeando)
        {
            AudioManager.instance.Play("Jump");
            velocitY.y = Mathf.Sqrt(jumpSpeed * gravedad * -2);
        }

        charCtrl.Move(velocitY * Time.deltaTime);

        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movX, 0, movY).normalized;

        if (movimiento.magnitude > 0.1 && !golpeando)
        {
            anim.SetBool("isMoving", true);
            float targetAngle = Mathf.Atan2(movimiento.x, movimiento.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothingVelo, smoothing);

            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 dirMov = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            charCtrl.Move(dirMov.normalized * velocidadActual * Time.deltaTime);
        }
        else 
        {
            anim.SetBool("isMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocidadActual = velocidadMax;
            anim.SetBool("isRunning", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidadActual = VelocidanNorm;
            anim.SetBool("isRunning", false);
        }

        if (Input.GetMouseButtonDown(0) && !golpeando && isGrounded)
        {
            anim.SetTrigger("attack");
            StartCoroutine(Esperar());

        }

        IEnumerator Esperar()
        {
            golpeando = true;
            yield return new WaitForSeconds(.8f);
            golpeando = false;

        }
        
    }
}
