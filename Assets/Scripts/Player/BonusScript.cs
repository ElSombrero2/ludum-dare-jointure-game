using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;


public class BonusScript : MonoBehaviour
{

    [SerializeField] private Material PlayerMaterial;
    [SerializeField] private Material LanceMaterial;
    [SerializeField] private Light2D PlayerLight;
    [SerializeField] private Light2D LanceLight;
    [SerializeField] private PlayerLight Light;

    private string color;

    void Start()
    {
        Blue();
    }

    public void Red()
    {
        PlayerLight.color = PlayerController.RED;
        PlayerMaterial.SetColor("_Color", PlayerController.RED);
        LanceLight.color = PlayerController.RED;
        LanceMaterial.color = PlayerController.RED;
        color = "Red";
        
    }

    public void Green()
    {
        PlayerLight.color = PlayerController.GREEN;
        PlayerMaterial.SetColor("_Color", PlayerController.GREEN);
        LanceLight.color = PlayerController.GREEN;
        LanceMaterial.color = PlayerController.GREEN;
        color = "Green";
    }

    public void Blue()
    {
        PlayerLight.color = PlayerController.BLUE;
        PlayerMaterial.SetColor("_Color", PlayerController.BLUE);
        LanceLight.color = PlayerController.BLUE;
        LanceMaterial.color = PlayerController.BLUE;
        color = "Blue";
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.layer == LayerMask.NameToLayer("Bonus"))
        {
            if (obj.CompareTag("Red"))Red();
            if(obj.CompareTag("Blue"))Blue();
            if(obj.CompareTag("Green"))Green();
            if (obj.CompareTag("Light")) Light.LightUp(0.2f);
            Destroy(obj.gameObject);
        }
    }

    public string GetColor()
    {
        return color;
    }

    public PlayerLight GetPlayerLight()
    {
        return Light;
    }

}
