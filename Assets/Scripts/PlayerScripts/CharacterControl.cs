using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterScript : MonoBehaviour
{
    public CharacterController charController;

    public Transform cam;

    public float speed = 6f;
    public float runSpeed = 6f;
    public float walkSpeed;
    
    bool isRunning = false;
    Vector2 moveVector;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();

        walkSpeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context){
        moveVector = context.ReadValue<Vector2>();
        // Horizontal: x, Vertical: y
    }

    void Move(){
        Vector3 direction = new Vector3(moveVector.x, 0f, moveVector.y).normalized;

        if (direction.magnitude >= 0.1f){

            animator.SetBool("iswalking", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            charController.Move(moveDir.normalized * speed * Time.deltaTime);
            
        } else {

            animator.SetBool("iswalking", false);

        }
    }

    public void SwitchIsRunning(){
        isRunning = !isRunning;

        animator.SetBool("isRunning", isRunning);
        
        if (isRunning){
            speed = runSpeed;
        } else
        {
            speed = walkSpeed;
        }
    }
}