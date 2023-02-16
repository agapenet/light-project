using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TheLab : MonoBehaviour
{
    public float intensity;
    public UnityEngine.Rendering.Universal.Light2D light;
    //might need to add experimental idk

    //then use something like this:
    public void start()
    {
        light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        light.intensity = 1;
    }
}
