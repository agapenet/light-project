using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Rendering.Universal;

public class WorldLight : MonoBehaviour
{
    private UnityEngine.Experimental.Rendering.Universal.Light2D guideLight;

    [SerializeField] private float fadeAmount;

    public float fadeSpeed = 1f;

    void Start()
    {
        guideLight = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        guideLight.intensity = 0;
    }

    void Awake()
    {
       
    }

    private void Update()
    {
        if(guideLight.intensity <= 1)
        {
            fadeAmount = guideLight.intensity + (fadeSpeed * Time.deltaTime);
            guideLight.intensity = fadeAmount;
        }
    } //eh do I need it though?
}
