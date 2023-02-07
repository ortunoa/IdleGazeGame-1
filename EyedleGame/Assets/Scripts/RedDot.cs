using UnityEngine;

public class RedDot : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = GameObject.Find("Camera").transform;

        // float halfWidth = Screen.width / 2;
        // float halfHeight = Screen.height / 2;

        // Vector3 topRight = new Vector3(halfWidth, halfHeight, 0);
        // Vector3 topLeft = new Vector3(0, halfHeight, 0);
        // Vector3 bottomLeft = new Vector3(0, 0, 0);
        // Vector3 bottomRight = new Vector3(halfWidth, 0, 0);

        // topRight = Camera.main.ScreenToWorldPoint(topRight);
        // topLeft = Camera.main.ScreenToWorldPoint(topLeft);
        // bottomLeft = Camera.main.ScreenToWorldPoint(bottomLeft);
        // bottomRight = Camera.main.ScreenToWorldPoint(bottomRight);

    }

    void Update()
    {

        transform.position = cameraTransform.position 
            // + cameraTransform.right * .5f 
            // + cameraTransform.up * 0.25f
            + cameraTransform.forward * 1f ;
        transform.LookAt(cameraTransform);
    }
}
