using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Rendering.Universal;

public class SolidLight : MonoBehaviour
{
    [SerializeField] private Collider2D bridgeCollider;

    public float duration;
    private float fadeTime;
    public bool activated = false;
    public UnityEngine.Experimental.Rendering.Universal.Light2D bridge;

    private void Start()
    {
        bridgeCollider.enabled = false;
        bridge.intensity = 0;
    }

    private void Update()
    {
        fadeTime = Time.deltaTime / duration;
    }

    public void ToggleState()
    {
       //not working yet
        if (activated == false)
        {
            Debug.Log("Starting fade in");
            bridge.intensity = 1;
            bridgeCollider.enabled = true;
            activated = true;
            return;
        }

        if (activated == true)
        {
            Debug.Log("Starting fade out");
            bridge.intensity = 0;
            bridgeCollider.enabled = false;
            activated = false;
            return;
        }
       // return;
       // StartCoroutine(FadeIn());
    }

    public void FadeIn()
    {
        bridge.intensity = Mathf.Lerp(0, 1, fadeTime);
        activated = true;
        return;
        //gave up on this
    }

    public void FadeOut()
    {
        bridge.intensity = Mathf.Lerp(1, 0, fadeTime);
        activated = false;
        return;
        //gave up on this
    }
}
