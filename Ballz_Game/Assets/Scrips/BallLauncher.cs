using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;

    [SerializeField]
    private GameObject ballPrefab;

    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * -10;

        if(Input.GetMouseButtonDown(0))
        {
            StratDrag(worldPosition);
        }
        else if(Input.GetMouseButton(0))
        {
            ContinueDrag(worldPosition);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
        
    }

    private void EndDrag()
    {
        Vector3 direction = endPosition - startPosition;
        direction.Normalize();

        var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().AddForce(-direction);
    }

    private void ContinueDrag(Vector3 worldPosition)
    {
        endPosition = worldPosition;
    }

    private void StratDrag(Vector3 worldPosition)
    {
        startPosition = worldPosition;
    }
}
