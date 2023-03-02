using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Rendering.Universal;

public class WorldLight : MonoBehaviour
{
    private UnityEngine.Experimental.Rendering.Universal.Light2D guideLight;

    private bool on = false;
    private float fadeAmount;
    public float fadeSpeed = 1f;

    void Start()
    {
        
    }

    void Awake()
    {
        guideLight = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        guideLight.intensity = 0;

        if(gameObject != null)
        {
            on = true;
        }
    }

    void Update()
    {
        fadeAmount = guideLight.intensity + (fadeSpeed * Time.deltaTime);
        guideLight.intensity = fadeAmount;
    } //eh do I need it though?
}
