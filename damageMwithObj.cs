using UnityEngine;

public class damage : MonoBehaviour
{
    public int damag = 4;
    public Health playerhealth;
 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerhealth.TakeDamage(damag);

            playerhealth = collision.gameObject.GetComponent<Health>();
        }
    }
}



