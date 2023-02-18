using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    public Transform followThis;
    public Transform immediateFollow;
    private Rigidbody rb;

    public float minDistance = 10f;
    public float maxDistance = 20f;
    public float walkSpeed = 5f;
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
        Vector3 followDir = followThis.position - transform.position;
        followDir.y = 0;
        float distance = followDir.magnitude;

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
            Debug.Log("The dot is far away and we are walking toward it: " + Vector3.Distance(this.transform.position, followThis.position));
            rb.AddForce(this.gameObject.transform.forward * walkSpeed);
            this.transform.position = Vector3.MoveTowards(this.transform.position, followThis.position, walkSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("The dot is too close");
        }
    }
}
