using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WL_Point : MonoBehaviour
{
    public GameObject guidePrefab;
    private GameObject guide;
    private bool on;

    public void ActivateGuide()
    {
        if (!on)
        {
            guide = Instantiate<GameObject>(guidePrefab, transform.position, transform.rotation);
            on = true;
        }
    }
}
