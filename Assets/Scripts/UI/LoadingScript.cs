using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class LoadingScript : MonoBehaviour
{
    [SerializeReference] private string[] Quoths;
    [SerializeReference] private TextMeshProUGUI UIText;

    void OnEnable()
    {
        var r=new Random();
        UIText.text=Quoths[r.Next(0, Quoths.Length - 1)];
    }
}
