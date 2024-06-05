using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script sirve para controlar el movimiento del jugador.
/// </summary>
public class MovimientoJugador : MonoBehaviour
{
    [HideInInspector]
    public CharacterController controller;
    public Vector3 playerVelocity;
    public static bool groundedPlayer;
    [Header("Movement Values")]
    [Range(0,10)] public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.8f;
    public bool estoyenrebote = false;
    [Header("References")]
    public Animator miAnim;
    //sonidos//
    public AudioSource jumpSound;
    //Platforms
    private Vector3 lastPlatformPosition = Vector3.zero;
    [Tooltip("The current floor that you are hitting as the player")]public GameObject actualFloor;
    public LayerMask layerfloor;
    public bool IsGrounded = false;
    public Vector3 publicdireccion = Vector3.zero;
    public Transform ref_rotation;
    public bool stop = false;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        jumpSound.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (stop == false)
        {
            if (miAnim.GetCurrentAnimatorStateInfo(0).IsTag("Locomotion"))
            {
                Locomotion();
            }
        }
        AnimatorValues();

            windforce(publicdireccion);
       
    }
    void LateUpdate()
    {
        grounded();
    }
    void Locomotion()
    {
        groundedPlayer = IsGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
            playerVelocity.y = 0f;
        Vector3 move = new Vector3(SimpleInput.GetAxis("Horizontal"), 0, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (move != Vector3.zero)
            gameObject.transform.forward = move;
        //Changes the height position of the player.
        if (SimpleInput.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            //sonido salto//
            jumpSound.Play();
        }
        if (SimpleInput.GetButtonDown("Jump") && estoyenrebote == true)
        {
            playerVelocity.y = 0;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            estoyenrebote = false;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;

        if (Rotacion.estaRotando == false)
            controller.Move(playerVelocity * Time.deltaTime);
    }



    public void windforce(Vector3 direccion)
    {
        Vector3  moveDirection = ref_rotation.TransformDirection(direccion);
        //playerVelocity += moveDirection;
        controller.Move(moveDirection * Time.deltaTime);
    }
    void AnimatorValues()
    {
        miAnim.SetFloat("H_Magnitud", new Vector2(SimpleInput.GetAxis("Horizontal"),0).magnitude);
        miAnim.SetBool("IsGrounded", groundedPlayer);
    }
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Rebote")
            estoyenrebote = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Rebote")
            estoyenrebote = false;
    }
    void grounded()
    {
            RaycastHit hit;
        if (Physics.SphereCast(transform.position , 0.5f, -transform.up, out hit, 0.7f, layerfloor))
        {
            IsGrounded = true;
            if (actualFloor != hit.transform.gameObject)
            {
                actualFloor = hit.transform.gameObject;
                lastPlatformPosition = hit.transform.position;
            }

            if (lastPlatformPosition == Vector3.zero)
                lastPlatformPosition = hit.transform.position;

            Vector3 platformMovement = hit.transform.position - lastPlatformPosition;
            if (platformMovement != Vector3.zero && !Input.GetButton("Jump"))
            {
                if (Rotacion.estaRotando == false)
                    controller.Move(platformMovement);
            }
            lastPlatformPosition = hit.transform.position;
        }
        else
        {
            IsGrounded = false;
            lastPlatformPosition = Vector3.zero;
           
        }     
    }
}
