using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{

    public GameObject playerGameObject;

    // Start is called before the first frame update
    void Start()
    {
        BushCreator bushCreator = Camera.main.GetComponent<BushCreator>();
        bool[][] map = BushLoading.LoadImage("b");
        bushCreator.createBushesFromMap(map, new Vector2(0, 0), new Vector2(4, 4));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = playerGameObject.transform.position;
        playerPosition.z = gameObject.transform.position.z;
        gameObject.transform.position = playerPosition;
    }
}
