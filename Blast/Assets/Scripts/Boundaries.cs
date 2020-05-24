using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    private float playerRadius;

    void Start()
    {

        CapsuleCollider2D playerCollider = GetComponent<CapsuleCollider2D>();
        playerRadius = playerCollider.bounds.extents.x;

        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x + playerRadius;
        maxX = topCorner.x - playerRadius;
        minY = bottomCorner.y + playerRadius;
        maxY = topCorner.y - playerRadius;


    }

    void Update()
    {

        // Get current position
        Vector3 pos = transform.position;

        // Horizontal contraint
        if (pos.x < minX) pos.x = minX;
        if (pos.x > maxX) pos.x = maxX;

        // vertical contraint
        if (pos.y < minY) pos.y = minY;
        if (pos.y > maxY) pos.y = maxY;

        // Update position
        transform.position = pos;
    }
}
