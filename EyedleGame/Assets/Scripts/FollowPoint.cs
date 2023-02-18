using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class FollowPoint : MonoBehaviour
{
    public Transform followThis;
    public Transform immediateFollow;
    private Rigidbody rb;

    public float minDistance = 10f;
    public float maxDistance = 20f;
    public float walkSpeed = .05f;
    public float turnSpeed = 0.4f;
    public float turnDelay = 0.25f;
    private float turnTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (followThis == null)
        {
            Debug.Log("No follow object assigned");
        }

        rb = this.transform.parent.gameObject.GetComponent<Rigidbody>();
        if (rb == null)
            rb = this.GetComponent<Rigidbody>();
        if (rb == null)
            Debug.Log("No rigid body found");
    }

    // Update is called once per frame
    void Update()
        {
            // Get the latest gaze point from the Tobii Eyetracker
            GazePoint gazePoint = TobiiAPI.GetGazePoint();

            if (gazePoint.IsValid)
            {
                // Convert the gaze point screen position to world position
                Vector3 gazePointInWorld = Camera.main.ScreenToWorldPoint(new Vector3(gazePoint.Screen.x, gazePoint.Screen.y, 10f));
                gazePointInWorld.y = 0f;

                // Set the position of the followThis transform to the gaze point position
                followThis.position = gazePointInWorld;
            }

            // Calculate the direction to followThis object and move towards it
            Vector3 followDir = followThis.position - transform.position;
            followDir.y = 0;
            float distance = followDir.magnitude;

            Debug.Log(followThis.position);

            if (distance > maxDistance)
            {
                followDir = followDir.normalized * maxDistance;
                followThis.position = transform.position + followDir;
            }

            immediateFollow.LookAt(followThis, Vector3.up);

            if (Time.time > turnTime + turnDelay)
            {
                this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, immediateFollow.rotation, turnSpeed);   
                turnTime = Time.time;
            }

            if (Vector3.Distance(this.transform.position, followThis.position) > minDistance)
            {
                rb.AddForce(this.gameObject.transform.forward * walkSpeed);
                this.transform.position = Vector3.MoveTowards(this.transform.position, followThis.position, walkSpeed * Time.deltaTime);
            }
            else
            {
                Debug.Log("The dot is too close");
            }
        }

}
