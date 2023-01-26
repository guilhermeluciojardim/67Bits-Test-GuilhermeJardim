using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    public bool isAttacking=false;
    private Vector3 moveDirection;
    private Vector3 velocity;
    [SerializeField] private float gravity;


   //References
    private CharacterController controller;
    private Animator anim;

    private SphereCollider spherePunch;

    private void Start(){ 
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        spherePunch = GetComponent<SphereCollider>();
    }
    private void Update(){
        Move();
        Attack();
    }
    
    private void Move(){

        float moveZ = Input.GetAxis("Vertical");
        float rotY = 3f * Input.GetAxis("Mouse X");

        transform.Rotate(0,rotY,0);
        
        moveDirection = new Vector3(0,0,moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        anim.SetBool("isMoving",true);
            
            if ((moveDirection != Vector3.zero) && (!Input.GetKey(KeyCode.LeftShift))){
                    WalkAnim();
            }
            else if ((moveDirection != Vector3.zero) && (Input.GetKey(KeyCode.LeftShift)) && (moveZ > 0)){
                RunAnim();
            }
            else if (moveDirection == Vector3.zero){
                IdleAnim();
            }
            moveDirection *= moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Attack(){
            if ((Input.GetKeyDown(KeyCode.Mouse0))&&(isAttacking==false)){
                    anim.SetBool("Attack1",true);
                    isAttacking=true;
                    StartCoroutine(WaitForPunchSphere());
                    StartCoroutine(WaitForNextAttack());   
        }
    }
    IEnumerator WaitForNextAttack(){
        yield return new WaitForSeconds(0.8f);
        anim.SetBool("Attack1",false);
        isAttacking=false;
        spherePunch.enabled=false;
    }
    IEnumerator WaitForPunchSphere(){
        yield return new WaitForSeconds(0.5f);
        spherePunch.enabled=true;
    }

    private void IdleAnim(){
        anim.SetFloat("Speed", 0,0.1f,Time.deltaTime);
    }
    private void WalkAnim(){
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f,0.1f,Time.deltaTime);
    }
    private void RunAnim(){
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1f,0.1f,Time.deltaTime);
    }
}
