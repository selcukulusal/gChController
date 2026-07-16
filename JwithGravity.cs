using UnityEngine;
using UnityEngine.InputSystem;


public class JwithGravity : MonoBehaviour
{
    public InputAction jumpAction;
    public Rigidbody2D playerRB;


    void Start()
    {
        jumpAction.Enable();
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (jumpAction.triggered)
        {
            playerRB.AddForce(Vector2.up * 180, ForceMode2D.Impulse);
        }
    }
}
