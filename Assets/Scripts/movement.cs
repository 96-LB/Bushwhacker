using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float rushMaxCooldown;
    public float rushLength;
    
    Camera cameraMain;

    float rushTimer;
    bool rush, rushing;
    Vector3 worldMousePos;
    Quaternion desiredRot;

    public void Start()
    {
        cameraMain = Camera.main;
    }

    public void Update()
    {
        worldMousePos = cameraMain.ScreenToWorldPoint(Input.mousePosition);
        Vector2 vRot = new Vector2(worldMousePos.x - transform.position.x, worldMousePos.y - transform.position.y);
        desiredRot = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(vRot.y, vRot.x) - 90);

        if (Input.GetMouseButtonDown(0) && rushTimer > 0)
        {
            rush = true;
        }
    }


    public void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRot, 0.1f);
        if (rush)
        {
            if (!rushing)
            {
                
            }
        }
    }
}
