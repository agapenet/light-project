using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Rendering.Universal;

public class WorldLight : MonoBehaviour
{
    private UnityEngine.Experimental.Rendering.Universal.Light2D guideLight;

    void Start()
    {
        
    }

    void Awake()
    {
        guideLight = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        guideLight.intensity = 0;

        if(gameObject != null)
        {
           guideLight.intensity = 1;
        }
    }

    private void OnEnable()
    {
        
    }
}
