using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float rushMaxCooldown = 1;
    public float rushPower = 4;
    public float speed = 200;
    public float turnMult = 1;
    public bool lockedRush = false;

    Camera cameraMain;
    Rigidbody2D rb2d;
    float rushTimer;
    bool rush, rushing;
    Vector3 worldMousePos;
    Quaternion desiredRot;

    public void Start()
    {
        cameraMain = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.drag = 1;
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
        if (Time.time > rushTimer || lockedRush)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRot, 0.1f * turnMult);
        }

        if (rush && Time.time > rushTimer)
        {
            rb2d.AddForce(transform.up * rushPower * speed * Time.fixedDeltaTime);
            rushTimer = Time.time + rushMaxCooldown;
            rush = false;
        }
        else
        {
            rb2d.AddForce(transform.up * speed * Time.fixedDeltaTime);
        }

    }
}