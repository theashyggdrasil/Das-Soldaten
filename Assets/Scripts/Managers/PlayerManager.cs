using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    //variables
    private Rigidbody2D rigidBody; // initializes an rigidbody for our sprite
    public static PlayerManager instance; // to allow for instantiation
    public float jumpForce = 6.0f; //jump force 
    public LayerMask groundLayer, enemyLayer; // public layermask to determine raycast layermask
    public bool isSpeedBoostOn, isDoubleJumpOn, movementOn, isTimerOn; // variables that pertain to powerups
    public int jumpCount = 0; // for double jump purposes
    public int characterHealth, coinCount; // sets the initial character health 
    private Animator anim; // initializes the animator
    public float timer;
    public Transform currentPosition;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // sets up the rigidbody component
        anim = GetComponent<Animator>(); // allows the use of the animator component
        instance = this; // allows for instantiation
        characterHealth = 3; // initializes character health
    }
    

    // Use this for initialization
    void Start () {
        movementOn = true;
        rigidBody.freezeRotation = true; // does not allow for rotation of the rigidbody to disable falling over
        
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.currentGameState == GameState.inGame) //if the game state is in game, the player can move around
        {
            if (movementOn)
            {
                Movement();
            }
            SpeedBoostStatus();
            DoubleJumpStatus();
            anim.SetBool("hit", false);
        }
        currentPosition.position = transform.position;
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            

            if (SpeedBoostStatus())
            {
                transform.Translate(Vector2.right * 8f * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 180);
            }
            else
            {
                transform.Translate(Vector2.right * 4f * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 180);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            
            if (SpeedBoostStatus())
            {
                transform.Translate(Vector2.right * 8f * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.Translate(Vector2.right * 4f * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 0);
            }


        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && IsGrounded())
        {
            anim.SetBool("walking", true);
            
        }
        else
        {
            anim.SetBool("walking", false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && DoubleJumpStatus())
        {
            if(jumpCount < 1)
                {
                    rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Forcemode2d.impulse adds an instant force impulse to the rigibody 2d using its mass
                    jumpCount++;
                

            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Forcemode2d.impulse adds an instant force impulse to the rigibody 2d using its mass
            
        }

        if (IsGrounded())
        {
           jumpCount = 0;
           anim.SetBool("jumping", false);
        }

        else if(!IsGrounded())
        {
            anim.SetBool("jumping", true);
        }
    }

    void Jump() // adds force to our rigidbody is the IsGrounded function returns true
    {
        if (IsGrounded())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Forcemode2d.impulse adds an instant force impulse to the rigibody 2d using its mass
        }
    }


    bool IsGrounded() // bool to return if IsGrounded is true or false based on the raycast
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.0f, groundLayer.value) || Physics2D.Raycast(transform.position, Vector2.down, 0.5f, enemyLayer.value)) //determine is a layer is touching another layer
        {
            return true;
        }
        else
        {
            return false;

        } 

    }

    public bool SpeedBoostStatus()
    {
        if (isSpeedBoostOn == true && isTimerOn == true)
        {
            StartCoroutine("Timer");
            return true;
        }
        else
        {
            isSpeedBoostOn = false;
            return false;
        }
    }

    public bool DoubleJumpStatus()
    {

        if (isDoubleJumpOn == true && isTimerOn == true)
        {
            StartCoroutine("Timer");
            return true;
        }
        else
        {
            isDoubleJumpOn = false;
            return false;
        }
    }

    public void CharacterHealth(bool recoilOn)
    {
        SoundManager.instance.hitAudio.Play();
        characterHealth--;
        anim.SetBool("hit", true);
        if(recoilOn == true)
        StartCoroutine("RecoilTimer");
        
        if (characterHealth == 0)
        {
            Death();
        }
    }

    public void BounceOff()
    {
        if(rigidBody.velocity.x > -5.0f)
        rigidBody.AddForce(new Vector2 (0, 12.5f), ForceMode2D.Impulse);
        else
            rigidBody.AddForce(new Vector2(0, 10.0f), ForceMode2D.Impulse);

        SoundManager.instance.enemyHitAudio.Play();
    }

    public void Death()
    {
        Destroy(gameObject);
        SoundManager.instance.heroDeathAudio.Play();
        GameManager.instance.GameOver();
    }

    IEnumerator Timer() // 5 second timer for powerups
    {
        //suspend execution
        isTimerOn = true;
        yield return new WaitForSeconds(timer);
        isTimerOn = false;
    }

    public void Recoil(bool recoilLeft)
    {
        if(recoilLeft)
        rigidBody.AddForce(new Vector2(-2.0f, 1.5f), ForceMode2D.Impulse);
        else
        rigidBody.AddForce(new Vector2(2.0f, 1.5f), ForceMode2D.Impulse);
    }


    IEnumerator RecoilTimer() // suspends movement
    {
        //suspend execution
        movementOn = false;
        yield return new WaitForSeconds(0.5f);
        movementOn = true;
    }

    public void CoinCount()
    {
        coinCount++;
        if(coinCount == 50)
        {
            GameManager.instance.currentGameState = GameState.nextLevel;
            Time.timeScale = 0.0f; // sets timescale to 0, so the gametime clock does not increase
        }
    }

}
