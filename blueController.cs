using UnityEngine;
using UnityEngine.UI;

public class avatarController : MonoBehaviour
{
    public Slider sliderA;
    private int minHealthA;
    private int maxHealth = 10;
    public GameObject projectilePrefabe;
    private float firetime;
    private float firerate = 2f;
    private Vector2 bulletA = new Vector2(3.221f, -3.025f);



    void Start()
    {
        minHealthA = maxHealth;
        sliderA.maxValue = maxHealth;
        sliderA.value = minHealthA;
    }
    void Update()
    {
        firetime += Time.deltaTime;

        if (firetime > firerate)
        {
            Instantiate(projectilePrefabe, bulletA, projectilePrefabe.transform.rotation);

            firetime = 0.2f;
        }
    }

    public void TakeDamage(int lvl3)
    {
        minHealthA -= lvl3;
        sliderA.value = minHealthA;

        if (minHealthA <= -0)
        {
            Destroy(gameObject);
        }
    }
}
