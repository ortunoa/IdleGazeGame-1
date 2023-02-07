using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public GameObject Character;
    public GameObject boundsObj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Call Respawn Function");
            RespawnRandom();
        }
    }

    public void RespawnRandom()
    {
        Bounds bounds = boundsObj.GetComponent<Collider>().bounds;
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);

        Character.transform.position = bounds.center + new Vector3(offsetX, 1f, offsetZ);

    }
}

