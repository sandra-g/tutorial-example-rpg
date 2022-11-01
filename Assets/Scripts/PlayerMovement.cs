using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float movementSpeed = 5f;
    private float jumpForce = 5f;

    //para groundcheck
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    //audio
    [SerializeField] private AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //getKeydown es teclado, getbuttondown es del inputmanager del unity
        if(Input.GetButtonDown("Jump") && isGrounded())//if (Input.GetKeyDown("space"))//works with just the first time we press
        {
            Jump();//lo separa en funcion: rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);//force applied to move it in the air
            //ponerle 0 le quita la fuerza que tenía y le pone 0.
            //calling the velocity that already has, now i can move and jump simultaneously
        }

        float horizontalInput = Input.GetAxis("Horizontal");//creamos variables en el ambito mas pequeño en el cual las usemos.
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);//estas 3 lineas reemplazan todo el bloque

        //if (Input.GetKey("up"))//works if we hold the key
        //{
        //    //rb.velocity = new Vector3(0, 0, 5);//forward is Z axis
        //    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 5f);
        //}

        //if (Input.GetKey("down"))//works if we hold the key
        //{
        //    //rb.velocity = new Vector3(0, 0, 5);//forward is Z axis
        //    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -5f);
        //}

        //if (Input.GetKey("right"))//works if we hold the key
        //{
        //    //rb.velocity = new Vector3(5, 0, 0);//right is X axis
        //    rb.velocity = new Vector3(5f, rb.velocity.y, rb.velocity.z);
        //}

        //if (Input.GetKey("left"))//works if we hold the key
        //{
        //    //rb.velocity = new Vector3(5, 0, 0);//right is X axis
        //    rb.velocity = new Vector3(-5f, rb.velocity.y, rb.velocity.z);
        //}
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);//google:unity groundcheck, or avoid air jump
        //donde creo la esfera, how big es la esfera, layer mask(que coge del unity, script le aparece un combobox para elegir)
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemieHead"))
        {
            Destroy(collision.transform.parent.gameObject);//destruye al enemigo
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);//force applied to move it in the air
        jumpSound.Play();
    }
}
