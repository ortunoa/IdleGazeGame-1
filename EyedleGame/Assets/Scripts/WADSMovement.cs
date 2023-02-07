using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WADSMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-this.gameObject.transform.right);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(this.gameObject.transform.right);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(this.gameObject.transform.forward);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(-this.gameObject.transform.forward);
    }
}
