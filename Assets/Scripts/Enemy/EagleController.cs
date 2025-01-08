using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{
    public float speed = 4f;
    public float AITick = 1f;

    public Rigidbody2D cRigidbody;
    public SpriteRenderer cRenderer;
    public Seeker cSeeker;
    public Transform player;
    public Transform waypointOrigin;

    private Path path;
    private int currentPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("UpdatePath", 0f, AITick); //
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentPoint = 0;
        }
    }

    void UpdatePath()
    {
        cSeeker.StartPath(cRigidbody.position, player.position, OnPathComplete);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If enemy in range, we look for the player
        // Otherwise we return to our origin point
        Vector3 dirPlayer = player.position - transform.position;
        Vector3 dirOrigin = waypointOrigin.position - transform.position;

        if (dirPlayer.magnitude < 5f)
        {
            if (path != null)
            {
                Vector3 dir = path.vectorPath[currentPoint] - transform.position;

                cRigidbody.velocity = dir.normalized * speed;

                if (dir.magnitude < 0.01 && currentPoint < path.vectorPath.Count)
                    currentPoint = currentPoint + 1;
            }
        }
        else if (dirOrigin.magnitude > 0.1f)
        {
            //Move eagle back to its original position

            cRigidbody.velocity = dirOrigin.normalized * speed;
        }
    }
}
