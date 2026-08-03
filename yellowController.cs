using UnityEngine;
using UnityEngine.UI;

public class simpsonController : MonoBehaviour
{
    private int heaHealthS;
    private int maxHealthS = 10;
    public GameObject projectilePrefaba;
    public Slider SliderS;
    private float firetimer;
    private float firerate = 2f;
    void Start()
    {
        heaHealthS = maxHealthS;
        SliderS.maxValue = maxHealthS;
        SliderS.value = heaHealthS;
    }
    void Update()
    {
        firetimer += Time.deltaTime;

        if (firetimer >= firerate)
        {
            Instantiate(projectilePrefaba, transform.position, projectilePrefaba.transform.rotation);

            firetimer = 0.8f;
        }
    }

    

    public void TakeDamage(int lvl)
{
    heaHealthS -= lvl;
    SliderS.value = heaHealthS;

    if (heaHealthS <= -0)
    {
        Destroy(gameObject);

    }
}
}
