using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;

    private int i;

    public Rigidbody2D player;
    public Rigidbody2D platform;
    private bool onPlatform;
    public bool move = false;

    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    
    void Update()
    {
        float frameRate = 0f;
        frameRate = Time.frameCount / Time.time;

        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        if(onPlatform == true)
        {
            
        }
    }

    private void FixedUpdate()
    {
        //from now on make sure all player physics stuff is under the same method, me.
        if(move == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
            onPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            onPlatform = false;
        }
    }

    public void StartMoving()
    {
        move = true;
    }

    public void StopMoving()
    {
        move = false;
    }
}
