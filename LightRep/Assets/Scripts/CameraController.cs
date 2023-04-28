using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Camera main;

    public Vector3 offset = new Vector3(0f, 1f, -10f);
    public float smoothTime = 0.25f;
    public float zoomSpeed = 1f;
    public float sizeAdjustment;
    private Vector3 velocity = Vector3.zero;

    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        //Application.targetFrameRate = 120;
        //I changed time step from 0.02 to 0.001 to remedy stutter
        QualitySettings.vSyncCount = 0;
        main.orthographic = true;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && sizeAdjustment < 10)
        {
            sizeAdjustment += .1f * smoothTime * zoomSpeed;
            playerController.freeze = 0;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && sizeAdjustment > 0)
        {
            sizeAdjustment -= sizeAdjustment;
            playerController.freeze = 1;
        }
    }

    void FixedUpdate()
    {
        float Vertical = Input.GetAxisRaw("Vertical");

        Vector3 targetPosition = player.position + offset;

        //Follows player smoothly
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //Looking up and down
        offset.y = 1 + (Vertical * 3f);
        //Zoom out
        main.orthographicSize = 5f + sizeAdjustment;
    }
}
