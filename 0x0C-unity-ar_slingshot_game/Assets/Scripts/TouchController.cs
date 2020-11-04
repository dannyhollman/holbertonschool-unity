using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    float distance = 0;
    public float power = 0;
    public Vector3 firstPosition;
    public Vector3 currentPosition;
    public Vector2 currentDelta;
    public bool dragging;
    public Vector3 direction;
    public bool shoot;
    bool touch;

    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        shoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (touch)
            return;
        //if (Input.touchCount > 0 && PlaneController.surfaceSelected)
        if (Input.touchCount > 0 && PlaneController.gameStarted)
        {
            touch = true;
            // Loop through touches
            foreach (Touch touch in Input.touches)
            {
                currentPosition = touch.position;
                currentDelta = touch.deltaPosition;
                // Check for first touch
                if (touch.phase == TouchPhase.Began)
                {
                    firstPosition = touch.position;
                    dragging = true;
                    distance = 0;
                }

                // Keep track of drag distance
                if (touch.deltaPosition.y < 0)
                    distance += touch.deltaPosition.magnitude;
                else if (touch.deltaPosition.y > 0)
                    distance -= touch.deltaPosition.magnitude;
                power = distance / 30;

                // Check for end of drag
                if (touch.phase == TouchPhase.Ended)
                {
                    //Debug.Log("Distance: " + distance);
                    dragging = false;
                    //power = distance;
                    if (distance > 0)
                        shoot = true;
                }
            }
            touch = false;
        }
    }
}
