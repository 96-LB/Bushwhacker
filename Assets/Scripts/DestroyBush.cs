using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBush : MonoBehaviour
{
    public Transform hitPoint;
    public LayerMask bushLayer;

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Hit();
        }
    }

    void Hit() {
        Collider2D[] bushesHit = new Collider2D[10];
        Collider2D destroyCollider = hitPoint.GetComponent<Collider2D>();
    
        int size = PhysicsScene2D.OverlapCollider(destroyCollider, bushesHit, bushLayer);

        for (int i = 0; i < size; i++) {
            Collider2D bush = bushesHit[i];
            Destroy(bush.gameObject);

            Debug.Log("Player hit " + bush.gameObject.name);
        }
    }
}
