using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroller : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1;

    [SerializeField]

    private float looksenesitivity = 5;

    [SerializeField]

    private float jumpheight = 10;

    [SerializeField]

    private float gravity = 9.81f;

    private Vector2 movevector;
    private Vector2 lookvector;
    private Vector3 rotation;
    private float verticalvelocity;

    private CharacterController characterController;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
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
            verticalvelocity = 0;
        }

        Vector3 move = transform.right * movevector.x + transform.forward * movevector.y + transform.up * verticalvelocity;
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
            animator.Play("jump");
            //jump();
        }
    }

    private void jump()
    {
        verticalvelocity = Mathf.Sqrt(jumpheight * gravity);
    }

}