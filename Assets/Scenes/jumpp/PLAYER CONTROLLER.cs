using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroller : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1;
    

    private float walkSpeed;
    
    [SerializeField]
    private float runSpeed = 5f;

    [SerializeField]

    private float looksenesitivity = 15f;

    [SerializeField]

    private float jumpheight = 2f;

    [SerializeField]

    private float gravity = 9.81f;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity ;
    public Transform cam;

    public bool isRunning = false;

    private Vector2 movevector;
    public Vector2 lookvector;
    public Vector3 rotation;
    private float verticalvelocity;

    private CharacterController characterController;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        walkSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }
    public void Onmove(InputAction.CallbackContext context)
    {
        movevector = context.ReadValue<Vector2>();
        

        if(movevector.magnitude > 0)

        {
            animator.SetBool("iswalking", true);
            
        }
        else
        {
            animator.SetBool("iswalking", false);
            
        }
    }

    private void Move()
    {
        verticalvelocity += -gravity * Time.deltaTime;

        if (characterController.isGrounded && verticalvelocity < 0)
        {
            verticalvelocity = -0.1f * gravity * Time.deltaTime;
        }

        Vector3 move = transform.right * movevector.x + transform.forward * movevector.y + transform.up * verticalvelocity;
        
        float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        
        // transform.rotation = Quaternion.Euler(0f, angle, 0f);
        
        // Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    public void onlook(InputAction.CallbackContext context)
    {
        lookvector = context.ReadValue<Vector2>();
    }

    private void Rotate()
    {
        rotation.y += lookvector.x * looksenesitivity * Time.deltaTime;
        transform.localEulerAngles = rotation;
    }


    public void Onjump(InputAction.CallbackContext context)
    {
        if (characterController.isGrounded && context.performed)
        {
            // animator.Play("Jumping");
            // jump();
        }
    }

    private void jump()
    {
        verticalvelocity = Mathf.Sqrt(jumpheight * gravity);
    }

    [ContextMenu("Switch Run")]
    public void SwitchIsRunning(){
        isRunning = !isRunning;

        animator.SetBool("isRunning", isRunning);

        if (isRunning){
            moveSpeed = runSpeed;
        } else
        {
            moveSpeed = walkSpeed;
        }
    }
}