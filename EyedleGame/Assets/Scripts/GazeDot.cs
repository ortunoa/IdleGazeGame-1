using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class GazeDot : MonoBehaviour
{
    public Vector3 gazeToWorldPosition;

    // Update is called once per frame
    void Update()
    {
        GazePoint gazePoint = TobiiAPI.GetGazePoint();
        if (gazePoint.IsValid)
        {
            // Convert the gaze point screen position to world position
            gazeToWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(gazePoint.Screen.x, gazePoint.Screen.y, 10f));
            gazeToWorldPosition.z = 0f;
        }
        else
        {
            // If the gaze point is invalid, set the position to a default value
            gazeToWorldPosition = new Vector3(0f, 0f, 0f);
        }

        this.transform.position = gazeToWorldPosition;
    }
}
