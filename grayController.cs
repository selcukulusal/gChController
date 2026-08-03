using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class gangsterController : MonoBehaviour
{
    public int minhealthG;
    private int maxhealthG = 20;
    public Slider sliderG;
    public float firerate = 2f;
    public float firetimer;

    public GameObject projectilePrefabo;
    public GameObject projectilePrefabo2;
    private Vector2 positionPep = new Vector2(-0.485f, 2.082f);
    private Vector2 positionSpt = new Vector2(-0.461f, 2.14f);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minhealthG = maxhealthG;
        sliderG.maxValue = maxhealthG;
        sliderG.value = minhealthG;
    }

    // Update is called once per frame
    void Update()
    {
        firetimer += Time.deltaTime;
        if (firetimer >= firerate)
        {
            firetimer = 0.7f;
            
            Instantiate(projectilePrefabo, positionPep, projectilePrefabo.transform.rotation);
            Instantiate(projectilePrefabo2, positionSpt, projectilePrefabo2.transform.rotation);
        }
    }

    public void TakeDamage(int lvl1)
    {
        minhealthG -= lvl1;
        sliderG.value = minhealthG;

        if (minhealthG <= -0)
        {
            Destroy(gameObject);
        }
    }
}
