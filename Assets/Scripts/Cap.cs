using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap : MonoBehaviour
{
    private float speed = 10f;
    private Vector2 lastClickedPos;
    private bool moving;

    // Update is called once per frame
    void Update()
    {
        // Right click
        if (Input.GetMouseButtonDown(1)) {
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }

        if (moving && (Vector2) this.transform.position != lastClickedPos) {
            float step = speed * Time.deltaTime;
            this.transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
        } else {
            moving = false;
        }
    }
}
