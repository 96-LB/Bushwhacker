using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBush : MonoBehaviour
{
    public Transform hitPoint;
    public float hitRange = 0.5f;
    public LayerMask bushLayer;

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            Hit();
        }
    }

    void Hit() {
        Collider2D[] bushesHit = Physics2D.OverlapCircleAll(hitPoint.position, hitRange, bushLayer);

        foreach (Collider2D bush in bushesHit) {
            Debug.Log("Player hit " + bush.name);
            Destroy(bush.gameObject);
        }
    }
}
