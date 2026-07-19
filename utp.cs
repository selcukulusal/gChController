using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{

    public GameObject currentTel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentTel != null)
            {
                transform.position = currentTel.GetComponent<Teleporter>().GetDestination().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("teleporter"))
        {
            currentTel = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("teleporter"))
        {
            if (collision.gameObject == currentTel)
            {
                currentTel = null;
            }
        }
    }
}
