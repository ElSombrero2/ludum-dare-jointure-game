using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    private static readonly int MaxHealth = 100;


    [SerializeField] private Light2D Light;
    [SerializeField] private Light2D LanceLight;
    [SerializeField,Range(0.0f,10.0f)] private float MaxTime;
    [SerializeField,Range(0,100)]private int PlayerLife = PlayerLight.MaxHealth;
    [SerializeField] private GameObject GameOverScene;

    private float count = 0;

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count>=MaxTime)LightDown();
        if (PlayerLife <= 0) Die();
    }

    public void LightDown()
    {
        if(Light.intensity>0) Light.intensity -= 0.1f;
        if(LanceLight.intensity>0) LanceLight.intensity -= 0.1f;
        count = 0;
        PlayerLife =(int)(MaxHealth*LanceLight.intensity);
    }

    public void LightUp(float intensity)
    {
        if (Light.intensity + intensity >= 1.0f) Light.intensity = 1;
        else Light.intensity += intensity;
        if (LanceLight.intensity + intensity >= 1.0f) LanceLight.intensity = 1;
        else LanceLight.intensity += intensity;
        PlayerLife = (int)(MaxHealth * LanceLight.intensity);
    }

    public void Die()
    {
        GameOverScene.SetActive(true);
        Destroy(gameObject);
    }
}
