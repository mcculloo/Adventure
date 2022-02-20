using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoballsinmymouth : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private float moveInput;
    private float moveInput2;
    public CharacterController controller;
    public bool isSprinting = false;
    float sprintSpeed;
    float OGspeed;
    public float gravity;
    float velocityY = 0.0f;
    public float jumpHeight = 1.5f;
    public bool isCrouching = false;
    float crouchSpeed;
    public static int Items;

    public Transform cam;
    public float mouseSensitivity;
    private float cameraPitch = 50f;
    bool lockCursor = true;
    [SerializeField][Range(0.0f,0.5f)]float mouseSmoothVelocity;
    [SerializeField][Range(0.0f,0.5f)]float mouseSmoothTime;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    private float OGmoveVel;
    [SerializeField][Range(0.0f,0.5f)]float moveSmoothVelocity = 0.3f;
    [SerializeField][Range(0.0f,1f)]float jumpMoveSmoothVelocity = 1f;
    public Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        OGspeed = speed;
        OGmoveVel = moveSmoothVelocity;
        sprintSpeed = speed * 1.5f;
        crouchSpeed = speed / 1.5f;
    
        if(lockCursor){
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void FixedUpdate() {

    }

    // Update is called once per frame
    void Update()
    {
    Movement();
    CamMovement();
    }

    void Movement(){
        moveInput = Input.GetAxisRaw("Horizontal");
        moveInput2 = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(moveInput, moveInput2).normalized;
        currentDir = Vector2.SmoothDamp(currentDir, direction, ref currentDirVelocity, moveSmoothVelocity);

        if(controller.isGrounded){
            velocityY=0.0f;
            moveSmoothVelocity = OGmoveVel;
        }
            velocityY += gravity * Time.deltaTime;

            if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            moveSmoothVelocity = jumpMoveSmoothVelocity;
            velocityY += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        Vector3 move = (transform.forward * currentDir.y + transform.right * currentDir.x) * speed + Vector3.up * velocityY;
        controller.Move(move * Time.deltaTime);


        if(Input.GetKeyDown(KeyCode.LeftShift)){
            isSprinting = true;
            speed = sprintSpeed;
        } 
        if(Input.GetKeyUp(KeyCode.LeftShift)) {
            isSprinting = false;
            speed = OGspeed;
        }

        if(Input.GetKeyDown(KeyCode.C)){
            isCrouching = true;
            isSprinting = false;
            speed = crouchSpeed;
            controller.height = 1f;
        } 
        if(Input.GetKeyUp(KeyCode.C)) {
            isCrouching = false;
            isSprinting = false;
             speed = OGspeed;
             controller.height = 2f;
        }         

    }

    void CamMovement(){
        //CAMERA ROTATE
        Vector2 mouseDirection = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, mouseDirection, ref currentMouseDeltaVelocity, mouseSmoothTime);
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
        cam.localEulerAngles = Vector3.right * cameraPitch;
            
    }

}
