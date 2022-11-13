using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = playerGameObject.transform.position;
        playerPosition.z = gameObject.transform.position.z;
        gameObject.transform.position = playerPosition;
    }
}
