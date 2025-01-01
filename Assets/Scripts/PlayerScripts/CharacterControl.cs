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
    
    public float gravity = 9.81f;
    private float verticalvelocity;
    bool isRunning = false;
    bool canMove = true;
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
        if (canMove){
            Move();
        }
    }

    public void OnMove(InputAction.CallbackContext context){
        moveVector = context.ReadValue<Vector2>();
        // Horizontal: x, Vertical: y
    }

    void Move(){

        if (charController.isGrounded)
        {
            verticalvelocity = -0.1f * gravity * Time.deltaTime;
        } else {
            verticalvelocity += -gravity * Time.deltaTime;
        }


        Vector3 direction = new Vector3(moveVector.x, 0f, moveVector.y).normalized;

        Vector3 moveDir = Vector3.zero;

        if (direction.magnitude >= 0.1f){

            SetAnimatorState("iswalking", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward ;

            
        } else {

            SetAnimatorState("iswalking", false);

        }
        charController.Move(moveDir.normalized * speed * Time.deltaTime + Vector3.up * verticalvelocity);
    }

    void SetAnimatorState(string parameter, bool state){
        if (animator != null){
            animator.SetBool(parameter, state);
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

    public void EnableMovement(){
        canMove = true;
    }

    public void DisableMovement(){
        canMove = false;
    }
}
