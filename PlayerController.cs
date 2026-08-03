using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Animator myAnim;
    public AudioSource firesound;
    public AudioClip collectB;
    public AudioClip hurt;
    private int speed = 1;
    public bool canJump;

    /* input system section starting */
    public InputAction moveAction;
    public InputAction fireAction;
    public InputAction jumpAction;
    /* input system ending */

    public Vector2 moveInput;
    private Rigidbody2D playerRB;

    public GameObject projectilePrefab;
    public bool FacingRight = false;

    void Start()
    {
        moveAction.Enable();
        fireAction.Enable();
        jumpAction.Enable();
        playerRB = GetComponent<Rigidbody2D>();
        firesound = GetComponent<AudioSource>();
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }



    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        transform.Translate(moveInput * Time.deltaTime * speed);

        if (moveInput.x > 0 && !FacingRight)
        {
            Flip();
        }

        else if (moveInput.x < 0 && FacingRight)
        {
            Flip();
        }


        if (fireAction.triggered)
        {
            GameObject proj = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            proj.GetComponent<DieHAHAHA>().direction1 = FacingRight ? 1 : -1;
            firesound.Play();
            myAnim.SetTrigger("fire");
        }

        if (jumpAction.triggered && canJump)
        {
            canJump = false;
            myAnim.SetTrigger("jump");
            playerRB.AddForce(Vector2.up * 180, ForceMode2D.Impulse);

        }

        if (moveInput != Vector2.zero)
        {
            myAnim.SetBool("isWalking", true);
        }

        else
        {
            myAnim.SetBool("isWalking", false);
        }

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bottle")
        {
            firesound.PlayOneShot(collectB);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "saw")
        {
            firesound.PlayOneShot(hurt);

        }
        canJump = true;

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemyBullet")
        {
            firesound.PlayOneShot(hurt);

        }


        if (other.gameObject.tag == "bottleD")
        {
            firesound.PlayOneShot(hurt);
            Destroy(other.gameObject);

        }
    }




}
