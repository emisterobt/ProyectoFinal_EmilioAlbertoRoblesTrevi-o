using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private float movX;
    private float movZ;

    [SerializeField]
    [Range(0, 100)]
    private float movSpeed;

    //Salto
    [SerializeField]
    [Range(0, 100)]
    private float jumpSpeed;

    //Dash Abajo
    [SerializeField]
    [Range(0, 100)]
    private float dashDown;

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

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        

    }

    private void Start()
    {
        AudioManager.instance.Play("Candy");
    }
    private void Update()
    {

        isGrounded = Physics.CheckSphere(groundCkeck.position, radio, whatIsGround);
        velocitY.y += gravedad * Time.deltaTime;
        if (isGrounded && velocitY.y <= 0)
        {
            velocitY.y = 0;
        }
        controller.Move(velocitY * Time.deltaTime);

        //Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            AudioManager.instance.Play("Jump");
            velocitY.y = Mathf.Sqrt(jumpSpeed * gravedad * -2);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isGrounded)
        {
            velocitY.y = (-1 * (dashDown)) *(Mathf.Sqrt(jumpSpeed * gravedad * -2));
        }


        movX = Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;
        movZ = Input.GetAxis("Vertical") * movSpeed * Time.deltaTime;

        //Es un vector que toma en cuenta la posicion local de el objeto
        Vector3 movimiento = (transform.right * movX) + (transform.forward * movZ);

        controller.Move(movimiento);
    }
}
