using UnityEngine;
using UnityEngine.UI;
public class helmetController : MonoBehaviour
{
    int minhealthHE;
    int maxHealthHe = 10;
    public Slider sliderHe;
    private float firerate = 2f;
    private float firetimer;
    private Vector2 bulletHe = new Vector2(1.690f, 0.960f);


    public GameObject projectilePrefabi;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minhealthHE = maxHealthHe;
        sliderHe.maxValue = maxHealthHe;
        sliderHe.value = minhealthHE;
    }

    // Update is called once per frame
    void Update()
    {
        firetimer += Time.deltaTime;
        if(firetimer >= firerate)
        {
            Instantiate(projectilePrefabi, bulletHe, projectilePrefabi.transform.rotation);

            firetimer = 0.9f;
        }
    }

    public void TakeDamage(int lvl2)
    {
        minhealthHE -= lvl2;
        sliderHe.value = minhealthHE;

        if (minhealthHE <= 0)
        {
            Destroy(gameObject);
        }
    }
}
