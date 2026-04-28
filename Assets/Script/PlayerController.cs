
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public float gravityModifier = 1f;
    public float jumpForce = 10f;
    public bool isOnGround = true;

    //animação
    private Animator playerAnim;

    //Game Over
    public bool gameOver = false;

    private void Start()
    { 
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && isOnGround)
        {
            playerRb.AddForce(
                Vector3.up * jumpForce,ForceMode.Impulse);

            isOnGround = false;

            //animação
            playerAnim.SetTrigger("Jump_trig");
        }
    }


   private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        //Morte do jogador
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }



    void FixedUpdate()
    {
        playerRb.AddForce(
            Vector3.down * (gravityModifier -1)
            * Physics.gravity.magnitude, ForceMode.Acceleration);
    }

}
