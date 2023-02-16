using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Rendering.Universal;

public class SolidLight : MonoBehaviour
{
    public float duration;
    private float fadeTime;
    public bool activated = false;
    public UnityEngine.Experimental.Rendering.Universal.Light2D bridge;

    private void Start()
    {
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
            StartCoroutine(FadeIn());
            return;
        }

        if (activated == true)
        {
            Debug.Log("Starting fade in");
            StartCoroutine(FadeOut());
            return;
        }
       // StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        bridge.intensity = Mathf.Lerp(0, 1, fadeTime);
        yield return null;
        activated = true;
    }

    IEnumerator FadeOut()
    {
        bridge.intensity = Mathf.Lerp(1, 0, fadeTime);
        yield return null;
        activated = false;
    }
}
