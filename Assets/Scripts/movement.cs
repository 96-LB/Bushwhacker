using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float rushMaxCooldown = 0;
    public float rushPower = 1000;
    public float speed = 1500;
    public float turnMult = 3;
    public float drag = 5;

    Camera cameraMain;
    Rigidbody2D rb2d;
    float rushTimer;
    Vector3 worldMousePos;
    Quaternion desiredRot;

    public void Start()
    {
        cameraMain = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.drag = drag;
    }

    public void Update()
    {
        worldMousePos = cameraMain.ScreenToWorldPoint(Input.mousePosition);
        Vector2 vRot = new Vector2(worldMousePos.x - transform.position.x, worldMousePos.y - transform.position.y);
        desiredRot = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(vRot.y, vRot.x) - 90);

        if (Input.GetMouseButtonDown(1) && Time.time > rushTimer)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(transform.up * rushPower);
            rushTimer = Time.time + rushMaxCooldown;
            Debug.Log("dash!");
        }
    }


    public void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRot, 0.1f * turnMult);
        rb2d.AddForce(transform.up * speed * Time.fixedDeltaTime);
    }
}