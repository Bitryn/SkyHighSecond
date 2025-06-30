using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerControl : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    
    public float jumpForce = 10f;
    public Vector2 BaseJumpForce = new Vector2(10f,0f);
    public Vector2 RotatedJumpForce ; 
    
    public bool InJump = false ;

    //private bool isGrounded;
    
    private Rigidbody2D rb;
    public GameObject mPointer;

    public Vector2 Speed;

    public InputSystem_Actions PlayerControls;
    public InputAction PlayerJump; //player controls
    public InputAction PlayerShoot;
    //private bool jboo;

    Vector2 ZeroV = new Vector2(1f,0f);
    float mouseAngle;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mPointer = GameObject.Find("pointer");
        Debug.Log("ACHTUNG");
    }



    void Update()
    {
        // Handle horizontal movement
        //float moveInput = Input.GetAxis("Horizontal");
        //rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

            // Handle jumping
        /*if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            print(rb.linearVelocity);
        }   */

/*
        bool jboo = PlayerJump.ReadValue<Button>();
        //Debug.Log(jboo);
        if (jboo is true)
        {
            Jump();
        }
*/
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) ;
        Vector2 mousePos = Mouse.current.position.ReadValue();
        mousePos += new Vector2(-250.0f, -200.0f);
        mouseAngle = Vector2.Angle(mousePos, ZeroV);
        Debug.DrawLine(Vector2.right, (mousePos * new Vector2(5.0f,5.0f) ), Color.magenta);
        if(mousePos.y > 0){
            mouseAngle *=-1;
        }

        // IMPLEMENT!!!   mPointer.rotation.z = mouseAngle;
        /////////////////DEBUGS//////////////////////
        //Debug.Log(mousePos);
        //Debug.Log(mouseAngle);
        //Debug.Log(      Rotate( BaseJumpForce, mouseAngle*1f)    );
        //Speed = mousePos;    m_LocalPosition

        GlobVar.instance.MouseAngle = mouseAngle;
        GlobVar.instance.PlayerPos = transform.position;
        
        rb.linearVelocity = Speed;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (!InJump &&  GlobVar.instance.PointerFree )
        {

        Debug.Log("JUMP??");
            RotatedJumpForce =Rotate( BaseJumpForce, mouseAngle*1f); 
            RotatedJumpForce.y *=  -1f;
            Speed +=   RotatedJumpForce;   //Rotate( BaseJumpForce, mouseAngle*1f);
            //Speed.y += jumpForce;
            InJump = true;
            //rb.linearVelocity = Speed;
        }
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log("Shoot for the");
    }

    private Vector2 Rotate(Vector2 Vec, float Deg){
        Vector2 res = Quaternion.AngleAxis(Deg, Vector3.forward)* Vec ;


        return res;
    }

    private void Awake(){
        PlayerControls = new InputSystem_Actions();
    }

    private void OnEnable(){
        PlayerJump.Enable();
        PlayerJump.performed += Jump;
        PlayerShoot.Enable();
        PlayerShoot.performed += Shoot;
    }

    private void OnDisable(){
        PlayerJump.Disable();
        PlayerShoot.Disable();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = true;
            Debug.Log("Touched the Ground");
            if (InJump){ 
                InJump = false;
                Debug.Log("Not in jump");
                
                Speed -= RotatedJumpForce;
                //rb.linearVelocity =new Vector2(0,0);
            }
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player is no longer on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isGrounded = false;
        }
    }



}