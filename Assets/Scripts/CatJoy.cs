using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CatJoy : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator myAnimationController;
    public float maxPos;
    public float moveSpeed;
    public float Jump;
    bool canJump;
    bool canMove = true;
    //bool onPhone = false;
    public Joystick movementJoystick;
    //public AudioSource audioPlayer;
    bool isPause = false;
    public AudioSource jumpSound;
    void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GetComponent<GameOver>().gameOver == true)
            canMove = false;
        //print(canMove);
        if (canMove) {
            float inputXPhone = movementJoystick.joystickVec.x;
            if (inputXPhone != 0)
            {
                myAnimationController.SetBool("isWalk", true);

            }
            else
            {
                myAnimationController.SetBool("isWalk", false);
            }
            if ((inputXPhone > 0.5 || inputXPhone < -0.5))
            {
                myAnimationController.SetBool("isRun", true);
            }
            if ((inputXPhone < 0.5 && inputXPhone > -0.5))
            {
                myAnimationController.SetBool("isRun", false);
            }
            if (inputXPhone > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (inputXPhone < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (canMove && movementJoystick.joystickVec.x != 0)
            {
                //rb.velocity = new Vector2(movementJoystick.joystickVec.x * moveSpeed, 0);

                //print(inputXPhone);
                transform.position += new Vector3(inputXPhone * moveSpeed * Time.deltaTime, 0, 0);
            }
        }
        
 
    }

    void Update()
    {
        if (GetComponent<GameOver>().gameOver == true)
            canMove= false;

        /*if (Input.GetKeyDown("s")) {
            myAnimationController.SetBool("isScratch", true);
            myAnimationController.SetBool("isWalk", false);
            myAnimationController.SetBool("isRun", false);
            canMove = false;
        }
        if (Input.GetKeyUp("s"))
        {
            myAnimationController.SetBool("isScratch", false);
            canMove = true;
        }
        if (canMove)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputXPhone = Input.acceleration.x;

            if (Input.GetKeyDown("d"))
            {
                //transform.eulerAngles = new Vector3(0, 0, 0);
                myAnimationController.SetBool("isWalk", true);

            }
            if (Input.GetKeyUp("d"))
            {
                if (Input.GetKey("a") == false)
                    myAnimationController.SetBool("isWalk", false);
            }
            if (Input.GetKeyDown("a"))
            {
                //transform.eulerAngles = new Vector3(0, 180, 0);
                myAnimationController.SetBool("isWalk", true);
            }
            if (Input.GetKeyUp("a"))
            {
                if (Input.GetKey("d") == false)
                    myAnimationController.SetBool("isWalk", false);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                myAnimationController.SetBool("isRun", true);
                moveSpeed = 2;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKey("d") == false && Input.GetKey("a") == false && inputXPhone == 0)
            {
                myAnimationController.SetBool("isRun", false);
                moveSpeed = 1;
            }
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                myAnimationController.SetBool("isJump", true);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Jump), ForceMode2D.Impulse);
                canJump = false;
            }
            if (inputX > 0 || inputXPhone > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (inputX < 0 || inputXPhone < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            
            if (onPhone && moveSpeed == 2 && (inputXPhone > 0.5 || inputXPhone < -0.5))
            {
                myAnimationController.SetBool("isRun", true);
            }
            if (onPhone && ((inputXPhone < 0.5 && inputXPhone > -0.5) || moveSpeed == 1)) {
                myAnimationController.SetBool("isRun", false);
            }
            if (inputXPhone != 0)
            {
                myAnimationController.SetBool("isWalk", true);
                onPhone = true;
            }
            transform.position += Vector3.right * inputXPhone * moveSpeed * Time.deltaTime;
            transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;
            //float xPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);
            //transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }*/


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Ground") {
            myAnimationController.SetBool("isJump", false);
            //audioPlayer.Play();
            canJump = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }

    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            gameObject.transform.position += new Vector3(0, -2, 0);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //gameObject.GetComponent<Rigidbody2D>().mass = 0f;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            audioPlayer.Play();
        }
    }*/


    public void onClickJump() {
        if (canMove && canJump)
        {
            myAnimationController.SetBool("isJump", true);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Jump), ForceMode2D.Impulse);
            canJump = false;
            jumpSound.Play();
        }
    }
    public void onClickSprintDown()
    {
        //myAnimationController.SetBool("isRun", true);
        moveSpeed = 2;

    }

    public void onClickSprintUp()
    {
        //myAnimationController.SetBool("isRun", false);
        moveSpeed = 1;
    }
    public void onClickItchDown() {
        /*myAnimationController.SetBool("isScratch", true);
        myAnimationController.SetBool("isWalk", false);
        myAnimationController.SetBool("isRun", false);
        canMove = false;*/
        isPause = !isPause;

        if (isPause)
        {
            myAnimationController.SetBool("isScratch", true);
            myAnimationController.SetBool("isWalk", false);
            myAnimationController.SetBool("isRun", false);
            canMove = false;
        }

        else
        {
            myAnimationController.SetBool("isScratch", false);
            canMove = true;
        }
    }

    public void onClickItchUp() {
        myAnimationController.SetBool("isScratch", false);
        canMove = true;
    }
}
