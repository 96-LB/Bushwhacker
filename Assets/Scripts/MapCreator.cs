using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BushCreator bushCreator = Camera.main.GetComponent<BushCreator>();
        bool[][] map = BushLoading.GetImage();
        bushCreator.createBushesFromMap(map, new Vector2(0, 0), new Vector2(4, 4));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
