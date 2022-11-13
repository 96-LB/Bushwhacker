using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;

    // Start is called before the first frame update
    void Start()
    {
        CreateMap(mapWidth, mapHeight);
    }

    public void CreateMap(int width, int height)
    {
        BushCreator bushCreator = Camera.main.GetComponent<BushCreator>();
        bool[][] map = BushLoading.GetNoise(width, height);
        bushCreator.createBushesFromMap(map, new Vector2(-30, -30), new Vector2(4, 4));
    }
}
