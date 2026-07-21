using UnityEngine;

public class Health : MonoBehaviour
{
    public int myhealth;
    public int maxhealth = 10;
    void Start()
    {
        myhealth = maxhealth;
    }

    public void TakeDamage(int lvl)
    {
        myhealth -=lvl;
        if(myhealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

