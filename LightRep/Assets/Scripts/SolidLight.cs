using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Rendering.Universal;

public class SolidLight : MonoBehaviour
{
    [SerializeField] private Collider2D bridgeCollider;

    public float duration;
    public float fadeSpeed;
    private float fadeAmount;
    public bool activated = false;
    public UnityEngine.Experimental.Rendering.Universal.Light2D bridge;

    private void Start()
    {
        bridgeCollider.enabled = false;
        bridge.intensity = 0;
    }

    private void Update()
    {
        if(activated == false && bridge.intensity >= 0)
        {
            fadeAmount = bridge.intensity - (fadeSpeed * Time.deltaTime);
            bridge.intensity = fadeAmount;
        }
        
        if(activated == true && bridge.intensity <= 1)
        {
            fadeAmount = bridge.intensity + (fadeSpeed * Time.deltaTime);
            bridge.intensity = fadeAmount;
        }
    }

    public void ToggleState()
    {
       //not working yet
        if (activated == false)
        {
            Debug.Log("Starting fade in");
            //bridge.intensity = 1;
            bridgeCollider.enabled = true;
            activated = true;
            return;
        }

        if (activated == true)
        {
            Debug.Log("Starting fade out");
            //bridge.intensity = 0;
            bridgeCollider.enabled = false;
            activated = false;
            return;
        }
    }
}
