 using UnityEngine;
using UnityEngine.UI;

public class hulkController : MonoBehaviour
{
    int minhealthH;
    int maxhealthH = 10;
    public Slider sliderH;
    public GameObject projectilePrefabu;
    float firerate = 2f;
    float firetimer;
    AudioSource die;
    private Vector2 bulletH = new Vector2(2.950f, 3.39f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minhealthH = maxhealthH;
        sliderH.maxValue = maxhealthH;
        sliderH.value = minhealthH;
        die = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        firetimer += Time.deltaTime;
        if (firetimer >= firerate)
        {

            Instantiate(projectilePrefabu, bulletH, projectilePrefabu.transform.rotation);
            die.Play();
            firetimer = 0.7f;
            
        }
    }

    public void TakeDamage(int lvl4)
    {
        minhealthH -= lvl4;
        sliderH.value = minhealthH;

        if (minhealthH <= -0)
        {
            Destroy(gameObject);
        }
    }
}
