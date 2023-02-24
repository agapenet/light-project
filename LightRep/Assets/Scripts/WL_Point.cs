using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WL_Point : MonoBehaviour
{
    public GameObject guidePrefab;
    private GameObject guide;

    public void ActivateGuide()
    {
        guide = Instantiate<GameObject>(guidePrefab, transform.position, transform.rotation);
    }
}
