using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeDot : MonoBehaviour
{
    public Vector3 gazeToWorldPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            gazeToWorldPosition = hit.point;
        }
        else
        {
            gazeToWorldPosition = ray.GetPoint(15f);
        }

        this.transform.position = gazeToWorldPosition;
        
    }
}
